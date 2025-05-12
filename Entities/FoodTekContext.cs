using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FoodTekEF.Entities;

public partial class FoodTekContext : DbContext
{
    public FoodTekContext()
    {
    }

    public FoodTekContext(DbContextOptions<FoodTekContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ClientLocation> ClientLocations { get; set; }

    public virtual DbSet<Clientdeteile> Clientdeteiles { get; set; }

    public virtual DbSet<DiscountCategory> DiscountCategories { get; set; }

    public virtual DbSet<DiscountsOffer> DiscountsOffers { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Issue> Issues { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemOption> ItemOptions { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Otp> Otps { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserNotification> UserNotifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-E8UDJO1;Initial Catalog=FoodTek;Integrated Security=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Carts__51BCD7B7CAE4DB22");

            entity.Property(e => e.CartStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Active");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeliveryAddress).HasColumnType("text");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalPrice)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Client).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Carts__ClientId__0F624AF8");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartItemId).HasName("PK__CartItem__488B0B0A47AFD3B6");

            entity.Property(e => e.Discount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FinalPrice)
                .HasComputedColumnSql("([Quantity]*([Price]-[Discount]))", true)
                .HasColumnType("decimal(22, 2)");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CartItems__CartI__0C85DE4D");

            entity.HasOne(d => d.Item).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CartItems__ItemI__0D7A0286");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC070688A330");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ItemCount).HasDefaultValue(0);
            entity.Property(e => e.NameAr)
                .HasMaxLength(255)
                .HasColumnName("NameAR");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("NameEN");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
        });

        modelBuilder.Entity<ClientLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClientLo__3214EC07D9C32E17");

            entity.Property(e => e.AddressHint).HasMaxLength(255);
            entity.Property(e => e.AddressName).HasMaxLength(100);
            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Province).HasMaxLength(50);
            entity.Property(e => e.Region).HasMaxLength(50);

            entity.HasOne(d => d.Client).WithMany(p => p.ClientLocations)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__ClientLoc__Clien__114A936A");
        });

        modelBuilder.Entity<Clientdeteile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Clientde__1788CC4CB4FA12CC");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.OrderCount).HasDefaultValue(0);
            entity.Property(e => e.Rate).HasColumnType("numeric(2, 1)");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Active");

            entity.HasOne(d => d.User).WithOne(p => p.Clientdeteile)
                .HasForeignKey<Clientdeteile>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clientdet__UserI__10566F31");
        });

        modelBuilder.Entity<DiscountCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC071BB8275A");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.DiscountCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__DiscountC__Categ__123EB7A3");

            entity.HasOne(d => d.Discount).WithMany(p => p.DiscountCategories)
                .HasForeignKey(d => d.DiscountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__DiscountC__Disco__1332DBDC");
        });

        modelBuilder.Entity<DiscountsOffer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC07DDE1F137");

            entity.HasIndex(e => e.Code, "UQ__Discount__A25C5AA7731C69F4").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.DescriptionAr).HasColumnName("DescriptionAR");
            entity.Property(e => e.DescriptionEn).HasColumnName("DescriptionEN");
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TitleAr)
                .HasMaxLength(255)
                .HasColumnName("TitleAR");
            entity.Property(e => e.TitleEn)
                .HasMaxLength(255)
                .HasColumnName("TitleEN");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Favorite__3214EC079A30D786");

            entity.HasIndex(e => new { e.ClientId, e.ItemId }, "UQ_Client_Item").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Client).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK_Favorites_Client");

            entity.HasOne(d => d.Item).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK_Favorites_Item");
        });

        modelBuilder.Entity<Issue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Issues__3214EC0736052B2F");

            entity.Property(e => e.ClientEmail).HasMaxLength(100);
            entity.Property(e => e.ClientFullName).HasMaxLength(100);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);

            entity.HasOne(d => d.Client).WithMany(p => p.Issues)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Issues__ClientId__17036CC0");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Item__3214EC07823E2F19");

            entity.ToTable("Item");

            entity.Property(e => e.AvgRate).HasColumnType("decimal(2, 1)");
            entity.Property(e => e.CounteAvailable).HasColumnName("counteAvailable");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ItemDescriptionAr)
                .HasColumnType("text")
                .HasColumnName("ItemDescriptionAR");
            entity.Property(e => e.ItemDescriptionEn)
                .HasColumnType("text")
                .HasColumnName("ItemDescriptionEN");
            entity.Property(e => e.ItemImage)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ItemNameAr)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ItemNameAR");
            entity.Property(e => e.ItemNameEn)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ItemNameEN");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.Items)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Category");
        });

        modelBuilder.Entity<ItemOption>(entity =>
        {
            entity.HasKey(e => e.OptionId).HasName("PK__ItemOpti__92C7A1FFD5059088");

            entity.ToTable("ItemOption");

            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsRequired).HasDefaultValue(false);
            entity.Property(e => e.OptionNameAr)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("OptionNameAR");
            entity.Property(e => e.OptionNameEn)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("OptionNameEN");
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemOptions)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK_Item");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3214EC07E894929E");

            entity.Property(e => e.CreatedBy).HasMaxLength(20);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsRead).HasDefaultValue(false);
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(20);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BCF8810C41E");

            entity.Property(e => e.CancellationReason).HasMaxLength(200);
            entity.Property(e => e.CreatedBy).HasMaxLength(20);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeliveryAddress).HasMaxLength(255);
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(20)
                .HasDefaultValue("New Order");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedBy).HasMaxLength(20);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED06810C0A0696");

            entity.Property(e => e.ItemOptions).HasMaxLength(255);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Item).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Client_CreatedBy_Admin");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__19DFD96B");
        });

        modelBuilder.Entity<Otp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OTPs__3214EC0769C4D71B");

            entity.ToTable("OTPs");

            entity.HasIndex(e => new { e.UserId, e.Otpcode }, "IX_OTPs_User_Code");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeviceInfo).HasMaxLength(255);
            entity.Property(e => e.ExpiresAt).HasColumnType("datetime");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(50)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Otpcode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("OTPCode");
            entity.Property(e => e.Otptype)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("OTPType");

            entity.HasOne(d => d.User).WithMany(p => p.Otps)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OTPs_Users");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ratings__3214EC075BC59D30");

            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Rating1).HasColumnName("Rating");

            entity.HasOne(d => d.Client).WithMany(p => p.RatingClients)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ratings__ClientI__1CBC4616");

            entity.HasOne(d => d.Driver).WithMany(p => p.RatingDrivers)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ratings__DriverI__1DB06A4F");

            entity.HasOne(d => d.Order).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ratings__OrderId__1EA48E88");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3213E83F3E372921");

            entity.ToTable("Role");

            entity.HasIndex(e => e.Name, "UQ__Role__72E12F1B80B85EA3").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.RoleNameEn)
                .HasMaxLength(50)
                .HasColumnName("Role Name EN");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tickets__3214EC07981FF8B5");

            entity.Property(e => e.ActionType).HasMaxLength(20);
            entity.Property(e => e.CreatedBy).HasMaxLength(20);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RefundAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Closed");
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .HasDefaultValue("Problem");
            entity.Property(e => e.UpdatedBy).HasMaxLength(20);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC070E5E3E61");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E47FFBEB42").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053401C08E8B").IsUnique();

            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .HasColumnName("fullname");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.JoinDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(512);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.ProfileImage).HasMaxLength(255);
            entity.Property(e => e.Role)
                .HasDefaultValue(3)
                .HasColumnName("role");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Role)
                .HasConstraintName("FK_users_role");
        });

        modelBuilder.Entity<UserNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_not__3213E83F08528AE7");

            entity.ToTable("user_notifications");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsRead)
                .HasDefaultValue(false)
                .HasColumnName("is_read");
            entity.Property(e => e.NotificationId).HasColumnName("notification_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Notification).WithMany(p => p.UserNotifications)
                .HasForeignKey(d => d.NotificationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__user_noti__notif__7849DB76");

            entity.HasOne(d => d.User).WithMany(p => p.UserNotifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__user_noti__user___7755B73D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
