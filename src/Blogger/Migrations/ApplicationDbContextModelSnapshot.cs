using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using Blogger.Models;

namespace Blogger.Migrations
{
    [ContextType(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        public override IModel Model
        {
            get
            {
                var builder = new BasicModelBuilder()
                    .Annotation("SqlServer:ValueGeneration", "Identity");
                
                builder.Entity("Blogger.Models.ApplicationUser", b =>
                    {
                        b.Property<int>("AccessFailedCount")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 0);
                        b.Property<string>("ConcurrencyStamp")
                            .ConcurrencyToken()
                            .Annotation("OriginalValueIndex", 0)
                            .Annotation("ShadowIndex", 1);
                        b.Property<string>("Email")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 2);
                        b.Property<bool>("EmailConfirmed")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 3);
                        b.Property<string>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 4);
                        b.Property<bool>("LockoutEnabled")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 5);
                        b.Property<DateTimeOffset?>("LockoutEnd")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 6);
                        b.Property<string>("NormalizedEmail")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 7);
                        b.Property<string>("NormalizedUserName")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 8);
                        b.Property<string>("PasswordHash")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 9);
                        b.Property<string>("PhoneNumber")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 10);
                        b.Property<bool>("PhoneNumberConfirmed")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 11);
                        b.Property<string>("SecurityStamp")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 12);
                        b.Property<bool>("TwoFactorEnabled")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 13);
                        b.Property<string>("UserName")
                            .Annotation("OriginalValueIndex", 14)
                            .Annotation("ShadowIndex", 14);
                        b.Key("Id");
                        b.Annotation("Relational:TableName", "AspNetUsers");
                    });
                
                builder.Entity("Blogger.Models.Post", b =>
                    {
                        b.Property<int>("PostId")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 0)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("PosterEmail")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 1);
                        b.Property<int>("PosterId")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 2);
                        b.Property<string>("Text")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 3);
                        b.Property<DateTime>("TimeStamp")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 4);
                        b.Property<string>("Title")
                            .Annotation("OriginalValueIndex", 5)
                            .Annotation("ShadowIndex", 5);
                        b.Key("PostId");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                    {
                        b.Property<string>("ConcurrencyStamp")
                            .ConcurrencyToken()
                            .Annotation("OriginalValueIndex", 0)
                            .Annotation("ShadowIndex", 0);
                        b.Property<string>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 1);
                        b.Property<string>("Name")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 2);
                        b.Property<string>("NormalizedName")
                            .Annotation("OriginalValueIndex", 3)
                            .Annotation("ShadowIndex", 3);
                        b.Key("Id");
                        b.Annotation("Relational:TableName", "AspNetRoles");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("ClaimType")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 0);
                        b.Property<string>("ClaimValue")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 1);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 2)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("RoleId")
                            .Annotation("OriginalValueIndex", 0)
                            .Annotation("ShadowIndex", 3);
                        b.Key("Id");
                        b.Annotation("Relational:TableName", "AspNetRoleClaims");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("ClaimType")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 0);
                        b.Property<string>("ClaimValue")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 1);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 2)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("UserId")
                            .Annotation("OriginalValueIndex", 0)
                            .Annotation("ShadowIndex", 3);
                        b.Key("Id");
                        b.Annotation("Relational:TableName", "AspNetUserClaims");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("LoginProvider")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 0);
                        b.Property<string>("ProviderDisplayName")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 1);
                        b.Property<string>("ProviderKey")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 2);
                        b.Property<string>("UserId")
                            .Annotation("OriginalValueIndex", 0)
                            .Annotation("ShadowIndex", 3);
                        b.Key("LoginProvider", "ProviderKey");
                        b.Annotation("Relational:TableName", "AspNetUserLogins");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("RoleId")
                            .Annotation("OriginalValueIndex", 0)
                            .Annotation("ShadowIndex", 0);
                        b.Property<string>("UserId")
                            .Annotation("OriginalValueIndex", 1)
                            .Annotation("ShadowIndex", 1);
                        b.Key("UserId", "RoleId");
                        b.Annotation("Relational:TableName", "AspNetUserRoles");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", "RoleId");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("Blogger.Models.ApplicationUser", "UserId");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("Blogger.Models.ApplicationUser", "UserId");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", "RoleId");
                        b.ForeignKey("Blogger.Models.ApplicationUser", "UserId");
                    });
                
                return builder.Model;
            }
        }
    }
}
