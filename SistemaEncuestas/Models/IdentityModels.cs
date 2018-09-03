using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SistemaEncuestas.Models
{
    
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        [StringLength(30)]
        public string Nombre { get; set; }
        [StringLength(30)]
        public string A_Paterno { get; set; }
        [StringLength(30)]
        public string A_Materno { get; set; }
        [StringLength(1)]
        public string Sexo { get; set; }
        [StringLength(10)]
        public string Id { get; set; }

        public virtual ICollection<Respuesta> Respuestas { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
           : base("Gabriel", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Categoria> Categorias { get; set; } //Crea el puente conexion a la base de datos 
        public object Respuestas { get; internal set; }
    }
}