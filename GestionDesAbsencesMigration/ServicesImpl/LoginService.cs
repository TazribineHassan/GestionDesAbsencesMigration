using GestionDesAbsencesMigration.Common;
using GestionDesAbsencesMigration.Models;
using GestionDesAbsencesMigration.services;
using GestionDesAbsencesMigration.Services;


namespace GestionDesAbsencesMigration.ServicesImpl
{
    public class LoginService : ILoginService
    {
        IProfesseurService professeurService;
        IEtudiantService etudiantService;
        IAdminService adminService;


        public LoginService(IAdminService adminService, IProfesseurService professeurService, IEtudiantService etudiantService)
        {
            this.adminService = adminService;
            this.professeurService = professeurService;
            this.etudiantService = etudiantService;
        }

        public object getUser(string email)
        {
            // check if the user is a professeur
            Professeur professeur = professeurService.GetProfesseurByEmail(email);
            if (professeur != null)
            {
                return professeur;
            }

            // check if the user is an etudiant
            Etudiant etudiant = etudiantService.GetEtudiantByEmail(email);
            if (etudiant != null)
            {
                return etudiant;
            }

            return null;
        }

        public object Login(string email, string password, string userType = null)
        {
            
            if (userType == null)
            {
                // check if the user is a professeur
                Professeur professeur = professeurService.GetProfesseurByEmail(email);
                if (professeur != null)
                {
                    if (password.Equals(Encryption.Decrypt(professeur.Password))) return professeur;
                    else return null;
                }

                // check if the user is an etudiant
                Etudiant etudiant = etudiantService.GetEtudiantByEmail(email);
                if (etudiant != null)
                {
                    if (password.Equals(Encryption.Decrypt(etudiant.Password))) return etudiant;
                    else return null;
                }

                return null;

            }
            else if (userType.Equals("admin"))
            {
                Administrateur administrateur = adminService.GetAdminByEmail(email);
                if (administrateur != null)
                {
                    if (password.Equals(Encryption.Decrypt(administrateur.Password))) return administrateur;
                    else return null;
                }
                return null;
            }
            else
            {

                return null;

            }

        }
    }
}
