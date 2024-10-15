using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IT_Store.Models;

public partial class CodexContext : IdentityDbContext<User,IdentityRole<int>,int>
{
    public CodexContext(DbContextOptions<CodexContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<ParentCategory> ParentCategories { get; set; }

    public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=ConnectionStrings:development");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__addresse__26A1118DA41FBA50");

            entity.ToTable("addresses");

            entity.Property(e => e.AddressId).HasColumnName("addressID");
            entity.Property(e => e.AddressLine1)
                .HasMaxLength(150)
                .HasColumnName("address_line_1");
            entity.Property(e => e.AddressLine2)
                .HasMaxLength(150)
                .HasColumnName("address_line_2");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Landmark)
                .HasMaxLength(100)
                .HasColumnName("landmark");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK__addresses__id__3B75D760");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__brands__06B772B933ACA717");

            entity.ToTable("brands");

            entity.Property(e => e.BrandId).HasColumnName("brandID");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__carts__415B03D83A57122C");

            entity.ToTable("carts");

            entity.Property(e => e.CartId)
                .ValueGeneratedNever()
                .HasColumnName("cartID");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.CartNavigation).WithOne(p => p.Cart)
                .HasForeignKey<Cart>(d => d.CartId)
                .HasConstraintName("FK__carts__cartID__4E88ABD4");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => new { e.CartId, e.ProductId }).HasName("PK__cart_ite__F38A0ECC1EB58A85");

            entity.ToTable("cart_items");

            entity.Property(e => e.CartId).HasColumnName("cartID");
            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cart_item__cartI__5165187F");

            entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cart_item__produ__52593CB8");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__categori__23CAF1F8D589513C");

            entity.ToTable("categories");

            entity.Property(e => e.CategoryId).HasColumnName("categoryID");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.ParentCategoryId).HasColumnName("parentCategory_id");

            entity.HasOne(d => d.ParentCategory).WithMany(p => p.Categories)
                .HasForeignKey(d => d.ParentCategoryId)
                .HasConstraintName("FK__categorie__paren__403A8C7D");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__orders__0809337D774FF456");

            entity.ToTable("orders");

            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK__orders__id__5629CD9C");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("order_items");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Order).WithMany()
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__order_ite__order__5812160E");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__order_ite__produ__59063A47");
        });

        modelBuilder.Entity<ParentCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__parentCa__23CAF1F84AA5A501");

            entity.ToTable("parentCategories");

            entity.Property(e => e.CategoryId).HasColumnName("categoryID");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<PaymentDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payment___3214EC27F756A421");

            entity.ToTable("payment_details");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.Provider)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("provider");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Order).WithMany(p => p.PaymentDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__payment_d__order__5BE2A6F2");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__products__2D10D14A80A60E65");

            entity.ToTable("products");

            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.BasePrice).HasColumnName("basePrice");
            entity.Property(e => e.BrandId).HasColumnName("brandID");
            entity.Property(e => e.CategoryId).HasColumnName("categoryID");
            entity.Property(e => e.Cover)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("cover");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("serialNumber");
            entity.Property(e => e.Summary)
                .HasMaxLength(500)
                .HasColumnName("summary");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__products__brandI__45F365D3");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__products__catego__44FF419A");

            entity.HasMany(d => d.ProductAttributes).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductsProductAttribute",
                    r => r.HasOne<ProductAttribute>().WithMany()
                        .HasForeignKey("ProductAttributesId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__productsP__Produ__4BAC3F29"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__productsP__produ__4AB81AF0"),
                    j =>
                    {
                        j.HasKey("ProductId", "ProductAttributesId").HasName("PK__products__D2840D89B1E2C1F3");
                        j.ToTable("productsProduct_attributes");
                        j.IndexerProperty<int>("ProductId").HasColumnName("productID");
                        j.IndexerProperty<int>("ProductAttributesId").HasColumnName("Product_attributes_ID");
                    });
        });

        modelBuilder.Entity<ProductAttribute>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product___3214EC279BC3F960");

            entity.ToTable("product_attributes");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AddOnPrice).HasColumnName("addOnPrice");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Value)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("value");
        });

        //modelBuilder.Entity<User>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("PK__users__3213E83F23FB87F6");

        //    entity.ToTable("users", tb => tb.HasTrigger("tr_createCart"));

        //    entity.HasIndex(e => e.Email, "UQ__users__AB6E61642E21E329").IsUnique();

        //    entity.HasIndex(e => e.Username, "UQ__users__F3DBC572086B24B4").IsUnique();

        //    entity.Property(e => e.Id).HasColumnName("id");
        //    entity.Property(e => e.Avatar)
        //        .HasMaxLength(200)
        //        .IsUnicode(false)
        //        .HasColumnName("avatar");
        //    entity.Property(e => e.CreatedAt)
        //        .HasColumnType("datetime")
        //        .HasColumnName("created_at");
        //    entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
        //    entity.Property(e => e.Email)
        //        .HasMaxLength(150)
        //        .IsUnicode(false)
        //        .HasColumnName("email");
        //    entity.Property(e => e.FirstName)
        //        .HasMaxLength(100)
        //        .HasColumnName("firstName");
        //    entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
        //    entity.Property(e => e.LastName)
        //        .HasMaxLength(100)
        //        .HasColumnName("lastName");
        //    entity.Property(e => e.Password)
        //        .IsUnicode(false)
        //        .HasColumnName("password");
        //    entity.Property(e => e.PhoneNumber)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("phone_number");
        //    entity.Property(e => e.Username)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("username");
        //});

        //OnModelCreatingPartial(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
