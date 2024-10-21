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

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Address>(entity =>
		{
			entity.HasKey(e => e.AddressId).HasName("PK__addresse__26A1118D37E8B6BE");

			entity.ToTable("addresses");

			entity.Property(e => e.AddressId).HasColumnName("addressID");
			entity.Property(e => e.AddressLine)
				.HasMaxLength(150)
				.HasColumnName("address_line");
			entity.Property(e => e.City)
				.HasMaxLength(50)
				.HasColumnName("city");
			entity.Property(e => e.Country)
				.HasMaxLength(50)
				.HasColumnName("country");
			entity.Property(e => e.CreatedAt)
				.HasColumnType("datetime")
				.HasColumnName("created_at");
			entity.Property(e => e.Landmark)
				.HasMaxLength(100)
				.HasColumnName("landmark");
			entity.Property(e => e.PhoneNumber)
				.HasMaxLength(20)
				.IsUnicode(false)
				.HasColumnName("phone_number");
			entity.Property(e => e.UserId).HasColumnName("userId");

			entity.HasOne(d => d.User).WithMany(p => p.Addresses)
				.HasForeignKey(d => d.UserId)
				.HasConstraintName("FK__addresses__userI__1F98B2C1");
		});
		modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__brands__06B772B9402C7536");

            entity.ToTable("brands");

            entity.HasIndex(e => e.Name, "UQ__brands__72E12F1B9E9BC4D7").IsUnique();

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
			entity.HasKey(e => e.CartId).HasName("PK__carts__415B03D81E38133F");

			entity.ToTable("carts");

			entity.Property(e => e.CartId).HasColumnName("cartID");
			entity.Property(e => e.CreatedAt)
				.HasColumnType("datetime")
				.HasColumnName("created_at");
			entity.Property(e => e.Total).HasColumnName("total");
			entity.Property(e => e.UpdatedAt)
				.HasColumnType("datetime")
				.HasColumnName("updated_at");
			entity.Property(e => e.UserId).HasColumnName("userID");

			entity.HasOne(d => d.User).WithMany(p => p.Carts)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK__carts__userID__08B54D69");
		});

		modelBuilder.Entity<CartItem>(entity =>
		{
			entity.HasKey(e => new { e.CartId, e.ProductId }).HasName("PK__cart_ite__F38A0ECCDBE63011");

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
				.HasConstraintName("FK__cart_item__cartI__0F624AF8");

			entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
				.HasForeignKey(d => d.ProductId)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK__cart_item__produ__10566F31");
		});

		modelBuilder.Entity<Category>(entity =>
		{
			entity.HasKey(e => e.CategoryId).HasName("PK__categori__23CAF1F80AC7B635");

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
				.HasConstraintName("FK__categorie__paren__6383C8BA");
		});

		modelBuilder.Entity<Order>(entity =>
		{
			entity.HasKey(e => e.OrderId).HasName("PK__orders__0809337D1C403214");

			entity.ToTable("orders");

			entity.Property(e => e.OrderId).HasColumnName("orderID");
			entity.Property(e => e.AddressId).HasColumnName("addressID");
			entity.Property(e => e.CreatedAt)
				.HasColumnType("datetime")
				.HasColumnName("created_at");
			entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
			entity.Property(e => e.Total).HasColumnName("total");
			entity.Property(e => e.UpdatedAt)
				.HasColumnType("datetime")
				.HasColumnName("updated_at");
			entity.Property(e => e.UserId).HasColumnName("userId");

			entity.HasOne(d => d.Address).WithMany(p => p.Orders)
				.HasForeignKey(d => d.AddressId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__orders__addressI__236943A5");

			entity.HasOne(d => d.User).WithMany(p => p.Orders)
				.HasForeignKey(d => d.UserId)
				.HasConstraintName("FK__orders__userId__22751F6C");
		});

		modelBuilder.Entity<OrderItem>(entity =>
		{
			entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK__order_it__BAD83E69CCB0EC59");

			entity.ToTable("order_items");

			entity.Property(e => e.OrderId).HasColumnName("orderID");
			entity.Property(e => e.ProductId).HasColumnName("productID");
			entity.Property(e => e.CreatedAt)
				.HasColumnType("datetime")
				.HasColumnName("created_at");
			entity.Property(e => e.Quantity).HasColumnName("quantity");
			entity.Property(e => e.UpdatedAt)
				.HasColumnType("datetime")
				.HasColumnName("updated_at");

			entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
				.HasForeignKey(d => d.OrderId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__order_ite__order__46B27FE2");

			entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
				.HasForeignKey(d => d.ProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__order_ite__produ__47A6A41B");
		});

		modelBuilder.Entity<ParentCategory>(entity =>
		{
			entity.HasKey(e => e.CategoryId).HasName("PK__parentCa__23CAF1F80D3FF314");

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
			entity.HasKey(e => e.Id).HasName("PK__payment___3214EC277778217F");

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
				.HasConstraintName("FK__payment_d__order__7F2BE32F");
		});

		modelBuilder.Entity<Product>(entity =>
		{
			entity.HasKey(e => e.ProductId).HasName("PK__products__2D10D14A583B59AD");

			entity.ToTable("products");

			entity.Property(e => e.ProductId).HasColumnName("productID");
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
			entity.Property(e => e.Instock).HasColumnName("instock");
			entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
			entity.Property(e => e.Name)
				.HasMaxLength(100)
				.HasColumnName("name");
			entity.Property(e => e.Price).HasColumnName("price");
			entity.Property(e => e.Quantity).HasColumnName("quantity");
			entity.Property(e => e.SerialNumber)
				.HasMaxLength(200)
				.IsUnicode(false)
				.HasColumnName("serialNumber");
			entity.Property(e => e.Summary)
				.HasMaxLength(500)
				.HasColumnName("summary");

			entity.HasOne(d => d.Brand).WithMany(p => p.Products)
				.HasForeignKey(d => d.BrandId)
				.HasConstraintName("FK__products__brandI__693CA210");

			entity.HasOne(d => d.Category).WithMany(p => p.Products)
				.HasForeignKey(d => d.CategoryId)
				.HasConstraintName("FK__products__catego__68487DD7");

			entity.HasMany(d => d.ProductAttributes).WithMany(p => p.Products)
				.UsingEntity<Dictionary<string, object>>(
					"ProductsProductAttribute",
					r => r.HasOne<ProductAttribute>().WithMany()
						.HasForeignKey("ProductAttributesId")
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("FK__productsP__Produ__6EF57B66"),
					l => l.HasOne<Product>().WithMany()
						.HasForeignKey("ProductId")
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("FK__productsP__produ__6E01572D"),
					j =>
					{
						j.HasKey("ProductId", "ProductAttributesId").HasName("PK__products__D2840D89C5393243");
						j.ToTable("productsProduct_attributes");
						j.IndexerProperty<int>("ProductId").HasColumnName("productID");
						j.IndexerProperty<int>("ProductAttributesId").HasColumnName("Product_attributes_ID");
					});
		});

		modelBuilder.Entity<ProductAttribute>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK__product___3214EC27CAF88387");

			entity.ToTable("product_attributes");

			entity.Property(e => e.Id)
				.ValueGeneratedNever()
				.HasColumnName("ID");
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

		base.OnModelCreating(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
