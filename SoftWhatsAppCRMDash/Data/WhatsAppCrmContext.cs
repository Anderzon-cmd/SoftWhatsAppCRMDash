using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftWhatsAppCRMDash.Models;

namespace SoftWhatsAppCRMDash.Data;

public partial class WhatsAppCrmContext : IdentityDbContext<IdentityUser>
{
    public WhatsAppCrmContext()
    {
    }

    public WhatsAppCrmContext(DbContextOptions<WhatsAppCrmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrito> Carritos { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Contexto> Contextos { get; set; }

    public virtual DbSet<EnterpriseContext> EnterpriseContexts { get; set; }

    public virtual DbSet<Entrega> Entregas { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Migration> Migrations { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ResenaProducto> ResenaProductos { get; set; }

    public virtual DbSet<SaleNote> SaleNotes { get; set; }

    public virtual DbSet<SaleNoteDetail> SaleNoteDetails { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Carrito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_carrito");

            entity.ToTable("carrito");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.PedidoId).HasColumnName("pedido_id");
            entity.Property(e => e.Precio)
                .HasPrecision(12, 6)
                .HasColumnName("precio");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Total)
                .HasPrecision(12, 6)
                .HasColumnName("total");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("fk_carrito_cliente");

            entity.HasOne(d => d.Producto).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("fk_carrito_producto");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_categoria");

            entity.ToTable("categoria");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.PadreId).HasColumnName("padre_id");

            entity.HasOne(d => d.Padre).WithMany(p => p.InversePadre)
                .HasForeignKey(d => d.PadreId)
                .HasConstraintName("fk_padre_categoria");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_cliente");

            entity.ToTable("cliente");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .HasColumnName("nombre");
            entity.Property(e => e.Numero)
                .HasMaxLength(50)
                .HasColumnName("numero");
            entity.Property(e => e.Photo)
                .HasMaxLength(200)
                .HasColumnName("photo");
            entity.Property(e => e.StateChat)
                .HasColumnName("state_chat")
                .HasDefaultValue(2);

            entity.Property(e => e.WhatsappId).HasColumnName("whatsapp_id");
        });

        modelBuilder.Entity<Contexto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_contexto");

            entity.ToTable("contexto");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Spromtcontext).HasColumnName("spromtcontext");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Contextos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("fk_contexto_cliente");
        });

        modelBuilder.Entity<EnterpriseContext>(entity =>
        {
            entity.HasKey(e => e.Nid).HasName("enterprise_context_pkey");

            entity.ToTable("enterprise_context");

            entity.Property(e => e.Nid).HasColumnName("nid");
            entity.Property(e => e.Sdata).HasColumnName("sdata");
            entity.Property(e => e.Spromptcontext).HasColumnName("spromptcontext");
        });

        modelBuilder.Entity<Entrega>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_entrega");

            entity.ToTable("entrega");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Precio)
                .HasPrecision(8, 2)
                .HasColumnName("precio");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_marca");

            entity.ToTable("marca");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Migration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("migrations_pkey");

            entity.ToTable("migrations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Batch).HasColumnName("batch");
            entity.Property(e => e.Migration1)
                .HasMaxLength(255)
                .HasColumnName("migration");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_pedido");

            entity.ToTable("pedido");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(255)
                .HasColumnName("ciudad");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.CosteTotal)
                .HasPrecision(16, 2)
                .HasColumnName("coste_total");
            entity.Property(e => e.Departamento)
                .HasMaxLength(255)
                .HasColumnName("departamento");
            entity.Property(e => e.Descuento)
                .HasPrecision(16, 2)
                .HasColumnName("descuento");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.EntregaId).HasColumnName("entrega_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.NumeroOrden)
                .HasMaxLength(8)
                .HasColumnName("numero_orden");
            entity.Property(e => e.Subtotal)
                .HasPrecision(16, 2)
                .HasColumnName("subtotal");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("fk_pedido_cliente");

            entity.HasOne(d => d.Entrega).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.EntregaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_pedido_entrega");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_producto");

            entity.ToTable("producto");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Imagen)
                .HasMaxLength(255)
                .HasColumnName("imagen");
            entity.Property(e => e.MarcaId).HasColumnName("marca_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Oferta)
                .HasMaxLength(2)
                .HasColumnName("oferta");
            entity.Property(e => e.Precio)
                .HasPrecision(16, 2)
                .HasColumnName("precio");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("fk_producto_categoria");

            entity.HasOne(d => d.Marca).WithMany(p => p.Productos)
                .HasForeignKey(d => d.MarcaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_producto_marca");
        });

        modelBuilder.Entity<ResenaProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_resena_producto");

            entity.ToTable("resena_producto");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Calificacion).HasColumnName("calificacion");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Mensaje)
                .HasMaxLength(200)
                .HasColumnName("mensaje");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");

            entity.HasOne(d => d.Cliente).WithMany(p => p.ResenaProductos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_resena_producto_cliente");

            entity.HasOne(d => d.Producto).WithMany(p => p.ResenaProductos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_resena_producto_producto");
        });

        modelBuilder.Entity<SaleNote>(entity =>
        {
            entity.HasOne(d => d.Client).WithMany(p => p.SaleNotes)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SaleNoteDetail>(entity =>
        {
            entity.HasIndex(e => e.ProductId, "IX_SaleNoteDetails_ProductId");

            entity.HasIndex(e => e.SaleNoteId, "IX_SaleNoteDetails_SaleNoteId");

            entity.HasOne(d => d.Product).WithMany(p => p.SaleNoteDetails).HasForeignKey(d => d.ProductId);

            entity.HasOne(d => d.SaleNote).WithMany(p => p.SaleNoteDetails).HasForeignKey(d => d.SaleNoteId);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_usuario");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Email, "uk_usuario_email").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(255)
                .HasColumnName("apellidos");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Imagen)
                .HasMaxLength(255)
                .HasColumnName("imagen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .HasColumnName("rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
