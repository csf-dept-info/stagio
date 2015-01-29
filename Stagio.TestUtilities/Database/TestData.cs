using System;
using System.Collections.Generic;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;

namespace Stagio.TestUtilities.Database
{
    public class TestData
    {
        #region Étudiants
        static public Student SubscribedStudent1
        {
            get
            {
                var student = new Student
                {
                    FirstName = "Marc-Antoine",
                    LastName = "Ferland",
                    PhoneNumber = "(418)-667-7829",
                    Password = "pomme123",
                    Identifier = "maferland@yopmail.com",
                    StudentId = "1231281",
                    Active = true,
                    Roles = new List<UserRole>
                    {
                        new UserRole {RoleName = RoleNames.Student},
                    }
                };
                return student;
            }
        }

        static public Student SubscribedStudent2
        {
            get
            {
                var student = new Student
                {
                    FirstName = "Marc-Antoine",
                    LastName = "Fortier",
                    PhoneNumber = "(418)-661-2463",
                    Password = "apple123",
                    StudentId = "1231234",
                    Identifier = "marcantoine.fortier@yopmail.com",
                    Active = false,
                    Roles = new List<UserRole>
                    {
                        new UserRole {RoleName = RoleNames.Student},
                    }
                };
                return student;
            }
        }

        static public Student SubscribedStudent3
          {
            get
            {
                var student = new Student
                {
                    FirstName = "Olivier",
                    LastName = "Roy",
                    PhoneNumber = "(418)-660-0834",
                    Password = "koala123",
                    StudentId = "1234123",
                    Identifier = "olivier.roy@yopmail.com",
                    Active = true,
                    Roles = new List<UserRole>
                    {
                        new UserRole {RoleName = RoleNames.Student}
                    }
                };
                return student;
            }
        }

        static public Student NotSubscribedStudent
        {
            get
            {
                var student = new Student
                {

                    FirstName = "Francis",
                    LastName = "Chandonnet",
                    Password = "salami123",
                    Identifier = "1234567",
                    StudentId = "1234567",
                    Active = true,
                    Roles = new List<UserRole>
                    {
                        new UserRole {RoleName = RoleNames.Student}
                    }
                };
                return student;
            }
        }

        static public Student ToSubscribeStudent
        {
            get
            {
                var student = new Student
                {
                    FirstName = "Robin",
                    LastName = "Gagnon",
                    PhoneNumber = "(418)-819-2938",
                    Password = "snapchat123",
                    StudentId = "1237418",
                    Identifier = "robin.gagnon@yopmail.com", 
                    Active = true,
                    Roles = new List<UserRole>
                    {
                        new UserRole {RoleName = RoleNames.Student}
                    }
                };
                return student;
            }
        }

        static public Student StudentWhoApplied
        {
            get
            {
                var student = new Student
                {
                    FirstName = "Jonathan",
                    LastName = "Plurien",
                    Password = "silence123",
                    Identifier = "jonathan_plurien@yopmail.com",
                    StudentId = "1234567",
                    Active = true,
                    Roles = new List<UserRole>
                    {
                        new UserRole {RoleName = RoleNames.Student}
                    }
                };
                return student;
            }
        }

        static public Student StudentWhoHadInterview
        {
            get
            {
                var student = new Student
                {
                    FirstName = "Aude",
                    LastName = "Javel",
                    PhoneNumber = "(581)-923-6375",
                    Password = "bleach123",
                    StudentId = "1234123",
                    Identifier = "au.de.javel@yopmail.com",
                    Active = true,
                    Roles = new List<UserRole>
                    {
                        new UserRole {RoleName = RoleNames.Student}
                    }
                };
                return student;
            }
        }

        static public Student StudentWhoWasAcceptedByCompany
        {
            get
            {
                var student = new Student
                {
                    FirstName = "Henri",
                    LastName = "Cochet",
                    PhoneNumber = "(418)-982-0902",
                    Password = "rebond123",
                    StudentId = "1234123",
                    Identifier = "hen.ricochet@yopmail.com",
                    Active = true,
                    Roles = new List<UserRole>
                    {
                        new UserRole {RoleName = RoleNames.Student}
                    }
                };
                return student;
            }
        }

        static public Student StudentWhoAcceptedInternship
        {
            get
            {
                var student = new Student
                {
                    FirstName = "Sarah",
                    LastName = "Fréchit",
                    PhoneNumber = "(581)-660-1232",
                    Password = "frisson123",
                    StudentId = "1234123",
                    Identifier = "sarah.frechit@yopmail.com",
                    Active = true,
                    Roles = new List<UserRole>
                    {
                        new UserRole {RoleName = RoleNames.Student}
                    }
                };
                return student;
            }
        }
        
        #endregion

        #region Entreprises
        static public Company Company1
        {
            get
            {
                var company = new Company
                {
                    Name = "A la distagio Inc",
                    Description = "Développement de solutions informatiques simples et fonctionnelles.",
                    Address = "123, Ricardo Road",
                    PhoneNumber = "(418)-913-9265",
                    Email = "aladistagio@yopmail.com",
                    WebSite = "http://aladistasio.ca"
                };
                return company;
            }
        }

        static public Company Company2
        {
            get
            {
                var company = new Company
                {
                    Name = "Libéo",
                    Description = "Libéo, une communauté de plus de 70 passionnés de Web, de technologies et de design qui crée des solutions numériques simples à des problèmes ...",
                    Address = "5700, boul. des Galeries",
                    PhoneNumber = "(418)-520-0739",
                    Email = "libeo@yopmail.com",
                    WebSite = "http://libeo.com/"
                };
                return company;
            }
        }

        static public Company Company3
        {
            get
            {
                var company = new Company
                {
                    Name = "Spektrum Media",
                    Description = "«La qualité et l’expertise d’une firme ne se mesurent pas par la quantité de clients, mais plutôt par le niveau de satisfaction de chacun d'eux.» Spektrum est une firme de développement logiciel spécialisée en Web. Nous sommes une firme d'expérience, dont l'objectif est de rester jeune. Ses principes s'écartent des modèles corporatifs formels et rigides afin de créer un climat de collaboration, de proximité et de transparence dans le cadre de tous ses travaux.",
                    Address = "4885 1ère Avenue, Québec, Qc, Canada, G1H 2T5",
                    PhoneNumber = "(418)-800-7440",
                    Email = "spektrummedia@yopmail.com",
                    WebSite = "http://spektrummedia.com/"
                };
                return company;
            }




        }

        static public Company Company4
        {
            get
            {
                var company = new Company
                {
                    Name = "CSST",
                    Description = "Indemnités et remboursement de frais, pour une maternité sans danger, accident du travail ou maladie professionnelle, assignation temporaire, droits et obligations",
                    Address = "4885 1ère Avenue, Québec, Qc, Canada, G1H 2T5",
                    PhoneNumber = "(418)-302-2227",
                    Email = "csst@yopmail.com",
                    WebSite = "http://csst.com/"
                };
                return company;
            }
        }

        static public Company Company5
        {
            get
            {
                var company = new Company
                {
                    Name = "Industrielle Alliance",
                    Description = "Votre ambition n’a pas de limites, nous l’avons compris. C’est pourquoi, au Groupe Industrielle Alliance, nous vous donnons tous les outils pour atteindre vos objectifs, pour vivre un stage à la hauteur de vos attentes. Qu’il s’agisse de défis stimulants, de possibilités de formation exceptionnelles ou d’un milieu de travail dynamique et chaleureux, vous trouverez chez nous tout ce que votre vision vous permet de désirer",
                    Address = "1080, Grande Allée Ouest",
                    PhoneNumber = "(418)-684-5000",
                    Email = "industrielle.alliance@yopmail.com",
                    WebSite = "http://industriellealliance.com/"
                };
                return company;
            }
        }

        static public Company Company6
        {
            get
            {
                var company = new Company
                {
                    Name = "Covéo",
                    Description =  "Mettez les connaissances de votre entreprise à la portée de vos employés et de vos clients, en toute sécurité, avec la technologie de recherche par pertinence ...",
                    Address = "3175 des Quatre-Bourgeois, bureau 200 ",
                    PhoneNumber = "(418)-263-1111",
                    Email = "media@coveo.com",
                    WebSite = "http://www.coveo.com/"
                };
                return company;
            }
        }
        #endregion

        #region Employés
        static public Employee Employee1
        {
            get
            {
                var employee = new Employee
                {
                    FirstName = "Pierre",
                    LastName = "Laroche",
                    PhoneNumber = "(418)-653-0943",
                    ExtensionNumber = "4534",
                    Password = "caillou123",
                    Identifier = "pierre.laroche@yopmail.com",
                    Roles = new List<UserRole>
                    {
                        new UserRole {RoleName = RoleNames.Employee}
                    }

                };

                return employee;
            }
        }

        static public Employee Employee2
        {
            get
            {
                var employee = new Employee
                {
                    FirstName = "Yvan",
                    LastName = "Dubois",
                    PhoneNumber = "(514)-671-3425",
                    ExtensionNumber = "0124523",
                    Password = "arbre123",
                    Identifier = "yvan.dubois@yopmail.com",
                    Roles = new List<UserRole>
                    {
                                 new UserRole {RoleName = RoleNames.Employee}
                    }
                };

                return employee;
            }
        }

        static public Employee Employee3
        {
            get
            {
                var employee = new Employee
                {
                    FirstName = "Alex",
                    LastName = "Thérieur",
                    PhoneNumber = "(581)-991-1293",
                    ExtensionNumber = "321",
                    Password = "dehors123",
                    Identifier = "alex.terrieur@yopmail.com",
                    Roles = new List<UserRole>
                    {
                                 new UserRole {RoleName = RoleNames.Employee}
                    }
                };

                return employee;
            }
        }
        #endregion

        #region Offres en validation
        static public InternshipOffer InternshipOfferOnValidation1
        {
            get
            {
                const string path = "\\TestFiles\\TestFile.pdf";
                var offer = new InternshipOffer
                {
                    Id = 1,
                    PublicationDate = new System.DateTime(2014, 10, 15),
                    Title = "Developpeur web non-renuméré",
                    Contact = StaffMember2,
                    OtherContact = null,
                    Description = "Notre centre développe des applications pédagogiques multimédias pour l'enseignement et l'apprentissage dans le domaine des sciences de la santé au niveau universitaire. Nous recherchons [...]",
                    Details  = new InternshipOfferDetails
                    {
                        SpecificHardwareAndSoftware = "PC Windows en mode sans-échec",
                        WorkingHours = "De 8h30 à 16h30",
                        HoursPerWeek = "35h",
                        HourlyWage = "10.50$/h"
                    },
                    NumberOfTrainees = 2,
                    PersonInCharge = StaffMember1,
                    Deadline = DateTime.Now.AddMonths(1),
                    Status = InternshipOffer.OfferStatus.OnValidation,
                    PathToExtraFile = path
                };

                return offer;
            }
        }

        static public InternshipOffer InternshipOfferOnValidation2
        {
            get
            {
                var offer = new InternshipOffer
                {
                    Title = "Developpeur web non-renuméré",
                    PublicationDate = new System.DateTime(2014, 10, 27),
                    Contact = StaffMember1,
                    OtherContact = StaffMember2,
                    Description = "Notre centre développe des applications pédagogiques multimédias pour l'enseignement et l'apprentissage dans le domaine des sciences de la santé au niveau universitaire. Nous recherchons [...]",
                    Details = new InternshipOfferDetails
                    {
                        SpecificHardwareAndSoftware = "Connaître Mac OS X, Linux et Windows 10",
                        WorkingHours = "De 8h30 à 18h30",
                        HoursPerWeek = "65h",
                        HourlyWage = "19.85$/h"
                    },
                    NumberOfTrainees = 2,
                    PersonInCharge = StaffMember1,
                    Deadline = DateTime.Now.AddMonths(2),
                    Status = InternshipOffer.OfferStatus.OnValidation
                };

                return offer;
            }
        }

        static public InternshipOffer InternshipOfferOnValidation3
        {
            get
            {
                var offer = new InternshipOffer
                {
                    Title = "Analyste applicatif",
                    PublicationDate = new System.DateTime(2014, 11, 01),
                    Contact = StaffMember1,
                    OtherContact = StaffMember2,
                    Description = "Nous sommes à la recherche d'un stagiaire pour être Analyste. L'étudiant sera très bien encadré par des analystes seniors...",
                    Details = new InternshipOfferDetails
                    {
                        SpecificHardwareAndSoftware = "Connaître Mac OS X, Linux et Windows 10",
                        WorkingHours = "De 8h30 à 18h30",
                        HoursPerWeek = "65h",
                        HourlyWage = "19.85$/h"
                    },
                    NumberOfTrainees = 2,
                    PersonInCharge = StaffMember1,
                    Deadline = DateTime.Now.AddDays(-1),
                    Status = InternshipOffer.OfferStatus.OnValidation
                };

                return offer;
            }
        }
        #endregion

        #region Offres en brouillon
        static public InternshipOffer InternshipOfferDraft1
        {
            get
            {
                var offer = new InternshipOffer
                {
                    PublicationDate = DateTime.Now,
                    Title = "Soutien technique",
                    Contact = StaffMember1,
                    OtherContact = StaffMember2,
                    Description = "Notre centre développe des applications pédagogiques multimédias pour l'enseignement et l'apprentissage dans le domaine des sciences de la santé au niveau universitaire. Nous recherchons [...]",
                    Details = new InternshipOfferDetails
                    {
                        SpecificHardwareAndSoftware = "Connaître Mac OS X, Linux et Windows 10",
                        WorkingHours = "De 8h30 à 16h30",
                        HoursPerWeek = "35h",
                        HourlyWage = "10.50$/h"
                    },
                    NumberOfTrainees = 2,
                    PersonInCharge = StaffMember2,
                    Deadline = DateTime.Now.AddMonths(3),
                    Status = InternshipOffer.OfferStatus.Draft,
                    PathToExtraFile = null
                };

                return offer;
            }
        }

        static public InternshipOffer InternshipOfferDraft2
        {
            get
            {
                var offer = new InternshipOffer
                {
                    Title = "Brouillon",
                    PublicationDate = DateTime.Now,
                    Contact = null,
                    OtherContact = null,
                    Description = null,
                    Details = null,
                    NumberOfTrainees = 2,
                    PersonInCharge = null,
                    Deadline = DateTime.Now.AddMonths(3)
                };

                return offer;
            }
        }

        static public InternshipOffer InternshipOfferDraft3
        {
            get
            {
                var offer = new InternshipOffer
                {
                    Title = "Soutien technique",
                    PublicationDate = new System.DateTime(2014, 10, 21),
                    Contact = StaffMember1,
                    OtherContact = StaffMember2,
                    Description = "Nous sommes à la recherche d'un stagiaire pour être soutien. L'étudiant sera très bien encadré par des soutiens seniors...",
                    Details = new InternshipOfferDetails
                    {
                        SpecificHardwareAndSoftware = "Un crayon de plomb et des feuilles de papier",
                        WorkingHours = "De 8h30 à 18h30",
                        HoursPerWeek = "65h",
                        HourlyWage = "19.85$/h"
                    },
                    NumberOfTrainees = 2,
                    PersonInCharge = StaffMember1,
                    Deadline = new System.DateTime(2015, 12, 11),
                    Status = InternshipOffer.OfferStatus.Draft
                };

                return offer;
            }
        }

        static public InternshipOffer InternshipOfferDraft4
        {
            get
            {
                var offer = new InternshipOffer
                {
                    Title = "Developpeur web",
                    PublicationDate = new System.DateTime(2014, 09, 30),
                    Contact = StaffMember1,
                    OtherContact = StaffMember2,
                    Description = "Libéo est une agence Web. Nous concevons et développons des solutions digitales pour les professionnels de santé et les entreprises présentent sue ces Marchés de la Santé : - Applications mobiles et tablettes, natives et multiplateformes - TV connectée (Affichage Dynamique Santé), Affichage Dynamique Corporate - Site Internet vitrine pour les professionnels de santé, - Web Application, Back-office, SaaS, Passionnés de technologies mobiles, Web, Affichage Dynamique, nous accompagnons nos clients dans la définition et la mise en œuvre de leur stratégie digitale.Vos principales missions : Vous conduirez les projets PHP qui vous seront confiés. Vous attachez de l’importance à la qualité de vos développements (architecture, design, variable naming, commenting, factoring, testing…). Vous assurerez les développements de différentes applications web et back-offices. Vous êtes en veille sur les dernières nouveautés techniques.",
                    Details = new InternshipOfferDetails
                    {
                        SpecificHardwareAndSoftware = "Connaître Mac OS X, Linux et Windows 10",
                        WorkingHours = "De 8h30 à 18h30",
                        HoursPerWeek = "65h",
                        HourlyWage = "19.85$/h"
                    },
                    NumberOfTrainees = 2,
                    PersonInCharge = StaffMember1,
                    Deadline = new System.DateTime(2014, 12, 11),
                    Status = InternshipOffer.OfferStatus.Draft
                };

                return offer;
            }
        }
        #endregion

        #region Offres publiées
        static public InternshipOffer InternshipOfferPublicated1
        {
            get
            {

                const string path = "\\TestFiles\\TestFile.pdf";
                var offer = new InternshipOffer
                {
                    Title = "Analyste applicatif",
                    PublicationDate = new System.DateTime(2014, 08, 27),
                    Contact = StaffMember1,
                    OtherContact = StaffMember2,
                    Description = "Notre centre développe des applications pédagogiques multimédias pour l'enseignement et l'apprentissage dans le domaine des sciences de la santé au niveau universitaire. Nous recherchons [...]",
                    Details = new InternshipOfferDetails
                    {
                        SpecificHardwareAndSoftware = "Connaître Mac OS X, Linux et Windows 10",
                        WorkingHours = "De 8h30 à 18h30",
                        HoursPerWeek = "65h",
                        HourlyWage = "18.85$/h"
                    },
                    NumberOfTrainees = 2,
                    PersonInCharge = StaffMember1,
                    Deadline = DateTime.Now.AddMonths(2),
                    Status = InternshipOffer.OfferStatus.Publicated,
                    PathToExtraFile = path
                };

                return offer;
            }
        }

        static public InternshipOffer InternshipOfferPublicated2
        {
            get
            {
                var offer = new InternshipOffer
                {
                    Title = "Developpeur web",
                    PublicationDate = new System.DateTime(2014, 11, 11),
                    Contact = StaffMember1,
                    OtherContact = StaffMember2,
                    Description = "Spektrum est une agence Web. Nous concevons et développons des solutions digitales pour les professionnels de santé et les entreprises présentent sue ces Marchés de la Santé : - Applications mobiles et tablettes, natives et multiplateformes - TV connectée (Affichage Dynamique Santé), Affichage Dynamique Corporate - Site Internet vitrine pour les professionnels de santé, - Web Application, Back-office, SaaS, Passionnés de technologies mobiles, Web, Affichage Dynamique, nous accompagnons nos clients dans la définition et la mise en œuvre de leur stratégie digitale.Vos principales missions : Vous conduirez les projets PHP qui vous seront confiés. Vous attachez de l’importance à la qualité de vos développements (architecture, design, variable naming, commenting, factoring, testing…). Vous assurerez les développements de différentes applications web et back-offices. Vous êtes en veille sur les dernières nouveautés techniques.",
                    Details = new InternshipOfferDetails
                    {
                        SpecificHardwareAndSoftware = "Connaître Mac OS X, Linux et Windows 10",
                        WorkingHours = "De 9h à 17h",
                        HoursPerWeek = "35h",
                        HourlyWage = "14.85$/h"
                    },
                    NumberOfTrainees = 2,
                    PersonInCharge = StaffMember1,
                    Deadline = DateTime.Now.AddMonths(3),
                    Status = InternshipOffer.OfferStatus.Publicated
                };

                return offer;
            }
        }

        static public InternshipOffer InternshipOfferPublicated3
        {
            get
            {
                var offer = new InternshipOffer
                {
                    Title = "Soutien technique",
                    PublicationDate = new System.DateTime(2014, 08, 29),
                    Contact = StaffMember2,
                    OtherContact = StaffMember1,
                    Description = "Nous sommes à la recherche d'un stagiaire pour être Soutien technique. L'étudiant sera très bien encadré par des soutiens seniors...",
                    Details = new InternshipOfferDetails
                    {
                        SpecificHardwareAndSoftware = "Connaître Mac OS X, Linux et Windows 10",
                        WorkingHours = "De 8h30 à 18h30",
                        HoursPerWeek = "65h",
                        HourlyWage = "12.85$/h"
                    },
                    NumberOfTrainees = 2,
                    PersonInCharge = StaffMember1,
                    Deadline = DateTime.Now.AddDays(1),
                    Status = InternshipOffer.OfferStatus.Publicated
                };

                return offer;
            }
        }

        static public InternshipOffer InternshipOfferPublicated4
        {
            get
            {
                var offer = new InternshipOffer
                {
                    Title = "Analyste applicatif",
                    PublicationDate = new System.DateTime(2014, 09, 27),
                    Contact = StaffMember2,
                    OtherContact = StaffMember1,
                    Description = "Nous sommes à la recherche d'un stagiaire pour être Analyste applicatif. L'étudiant sera très bien encadré par des analystes seniors...",
                    Details = new InternshipOfferDetails
                    {
                        SpecificHardwareAndSoftware = "Connaître Mac OS X, Linux et Windows 10",
                        WorkingHours = "De 8h30 à 18h30",
                        HoursPerWeek = "65h",
                        HourlyWage = "21.85$/h"
                    },
                    NumberOfTrainees = 2,
                    PersonInCharge = StaffMember1,
                    Deadline = DateTime.Now,
                    Status = InternshipOffer.OfferStatus.Publicated
                };

                return offer;
            }
        }
        #endregion

        #region Membres d'entreprise
        static public StaffMember StaffMember1
        {
            get
            {
                var staffMember = new StaffMember
                {
                    Name = "Suzie Lapointe",
                    Title = "Coordonatrice aux développements d'applications pédagogiques",
                    PhoneNumber = "(418)-661-7654",
                    Email = "suzie.lapointe@yopmail.com"   
                };

                return staffMember;
            }
        }
        static public StaffMember StaffMember2
        {
            get
            {
                var staffMember = new StaffMember
                {
                    Name = "Fabien Lamour",
                    Title = "Directeur aux ressources humaines",
                    PhoneNumber = "(514)-876-4598",
                    Email = "fabien.lamour@yopmail.com"
                };

                return staffMember;
            }
        }
        #endregion

        #region Coordonnateurs
        static public Coordinator Coordinator1
        {
            get
            {
                var coordinator = new Coordinator
                {
                    FirstName = "Yvon",
                    LastName = "Gagné",
                    PhoneNumber = "(418)-898-3421",
                    Password = "hockey123",
                    Identifier = "yvon.gagne@yopmail.com",
                    Roles = new List<UserRole>
                             {
                                 new UserRole {RoleName = RoleNames.Coordinator}
                             }
                };

                return coordinator;
            }
        }
        #endregion

        #region Applications de stage
        static public InternshipApplication InternshipApplication1
        {
            get
            {
                string path = "\\TestFiles\\ExtraFile.pdf";
                var internshipApplication = new InternshipApplication()
                {
                    PathToResume = path,
                    PathToCoverLetter = path,
                    ApplicationDate = new DateTime(2014, 9, 11),
                    InterviewDate = new DateTime(2014, 10, 3),
                    CompanyAcceptedDate = new DateTime(2014, 10, 25),
                    StudentAcceptedDate = new DateTime(2014, 10, 26),
                    Progression = InternshipApplication.ApplicationStatus.StudentHasApplied
                };
                return internshipApplication;
            }
        }
        static public InternshipApplication InternshipApplication2
        {
            get
            {
                string path = "\\TestFiles\\ExtraFile.pdf";
                var internshipApplication = new InternshipApplication()
                {
                    PathToResume = path,
                    PathToCoverLetter = path,
                    ApplicationDate = new DateTime(2014, 9, 16),
                    InterviewDate = new DateTime(2014, 10, 8),
                    CompanyAcceptedDate = new DateTime(2014, 11, 4),
                    StudentAcceptedDate = new DateTime(2014, 11, 4),
                    Progression = InternshipApplication.ApplicationStatus.StudentHasApplied
                };
                return internshipApplication;
            }
        }
        static public InternshipApplication InternshipApplication3
        {
            get
            {
                string path = "\\TestFiles\\ExtraFile.pdf";
                var internshipApplication = new InternshipApplication()
                {
                    PathToResume = path,
                    PathToCoverLetter = path,
                    ApplicationDate = new DateTime(2014, 8, 12),
                    InterviewDate = new DateTime(2014, 10, 5),
                    CompanyAcceptedDate = new DateTime(2014, 10, 27),
                    StudentAcceptedDate = new DateTime(2014, 11, 2),
                    Progression = InternshipApplication.ApplicationStatus.StudentHasApplied
                };
                return internshipApplication;
            }
        }
       
        //Student 2 applications
        static public InternshipApplication InternshipApplication4
        {
            get
            {
                string path = "\\TestFiles\\ExtraFile.pdf";
                var internshipApplication = new InternshipApplication()
                {
                    PathToResume = path,
                    PathToCoverLetter = path,
                    ApplicationDate = new DateTime(2014, 8, 6),
                    InterviewDate = new DateTime(2014, 9, 5),
                    CompanyAcceptedDate = new DateTime(2014, 9, 27),
                    StudentAcceptedDate = new DateTime(2014, 10, 23),
                    Progression = InternshipApplication.ApplicationStatus.StudentHasApplied
                };
                return internshipApplication;
            }
        }
        static public InternshipApplication InternshipApplication5
        {
            get
            {
                string path = "\\TestFiles\\ExtraFile.pdf";
                var internshipApplication = new InternshipApplication()
                {
                    PathToResume = path,
                    PathToCoverLetter = path,
                    ApplicationDate = new DateTime(2014, 9, 29),
                    InterviewDate = new DateTime(2014, 10, 11),
                    CompanyAcceptedDate = new DateTime(2014, 10, 24),
                    StudentAcceptedDate = new DateTime(2014, 11, 3),
                    Progression = InternshipApplication.ApplicationStatus.StudentHadInterview
                };
                return internshipApplication;
            }
        }
        static public InternshipApplication InternshipApplication6
        {
            get
            {
                string path = "\\TestFiles\\ExtraFile.pdf";
                var internshipApplication = new InternshipApplication()
                {
                    PathToResume = path,
                    PathToCoverLetter = path,
                    ApplicationDate = new DateTime(2014, 10, 01),
                    InterviewDate = new DateTime(2014, 10, 11),
                    CompanyAcceptedDate = new DateTime(2014, 10, 24),
                    StudentAcceptedDate = new DateTime(2014, 10, 27),
                    Progression = InternshipApplication.ApplicationStatus.CompanyAcceptedStudent
                };
                return internshipApplication;
            }
        }
        static public InternshipApplication InternshipApplication7
        {
            get
            {
                string path = "\\TestFiles\\ExtraFile.pdf";
                var internshipApplication = new InternshipApplication()
                {
                    PathToResume = path,
                    PathToCoverLetter = path,
                    ApplicationDate = new DateTime(2014, 10, 02),
                    InterviewDate = new DateTime(2014, 10, 07),
                    CompanyAcceptedDate = new DateTime(2014, 10, 22),
                    StudentAcceptedDate = new DateTime(2014, 10, 29),
                    Progression = InternshipApplication.ApplicationStatus.StudentAcceptedOffer
                };
                return internshipApplication;
            }
        }

        //Student progress test data
        static public InternshipApplication InternshipApplication8
        {
            get
            {
                string path = "\\TestFiles\\ExtraFile.pdf";
                var internshipApplication = new InternshipApplication()
                {
                    PathToResume = path,
                    PathToCoverLetter = path,
                    ApplicationDate = new DateTime(2014, 8, 6),
                    InterviewDate = new DateTime(2014, 9, 5),
                    CompanyAcceptedDate = new DateTime(2014, 9, 27),
                    StudentAcceptedDate = new DateTime(2014, 10, 23),
                    Progression = InternshipApplication.ApplicationStatus.StudentHasApplied
                };
                return internshipApplication;
            }
        }
        static public InternshipApplication InternshipApplication9
        {
            get
            {
                string path = "\\TestFiles\\ExtraFile.pdf";
                var internshipApplication = new InternshipApplication()
                {
                    PathToResume = path,
                    PathToCoverLetter = path,
                    ApplicationDate = new DateTime(2014, 9, 29),
                    InterviewDate = new DateTime(2014, 10, 11),
                    CompanyAcceptedDate = new DateTime(2014, 10, 24),
                    StudentAcceptedDate = new DateTime(2014, 11, 3),
                    Progression = InternshipApplication.ApplicationStatus.StudentHadInterview
                };
                return internshipApplication;
            }
        }
        static public InternshipApplication InternshipApplication10
        {
            get
            {
                string path = "\\TestFiles\\ExtraFile.pdf";
                var internshipApplication = new InternshipApplication()
                {
                    PathToResume = path,
                    PathToCoverLetter = path,
                    ApplicationDate = new DateTime(2014, 10, 01),
                    InterviewDate = new DateTime(2014, 10, 11),
                    CompanyAcceptedDate = new DateTime(2014, 10, 24),
                    StudentAcceptedDate = new DateTime(2014, 10, 27),
                    Progression = InternshipApplication.ApplicationStatus.CompanyAcceptedStudent
                };
                return internshipApplication;
            }
        }
        static public InternshipApplication InternshipApplication11
        {
            get
            {
                string path = "\\TestFiles\\ExtraFile.pdf";
                var internshipApplication = new InternshipApplication()
                {
                    PathToResume = path,
                    PathToCoverLetter = path,
                    ApplicationDate = new DateTime(2014, 10, 02),
                    InterviewDate = new DateTime(2014, 10, 07),
                    CompanyAcceptedDate = new DateTime(2014, 10, 22),
                    StudentAcceptedDate = new DateTime(2014, 10, 29),
                    Progression = InternshipApplication.ApplicationStatus.StudentAcceptedOffer
                };
                return internshipApplication;
            }
        }
        #endregion

        #region Périodes de stage
        static public InternshipPeriod ValidInternshipPeriod
        {
            get
            {
                var internshipPeriod = new InternshipPeriod
                {
                    StartDate = DateTime.Today.AddMonths(-1),
                    EndDate = DateTime.Today.AddMonths(1)
                };
                
                return internshipPeriod;
            }
        }

        static public InternshipPeriod InvalidInternshipPeriod
        {
            get
            {
                var internshipPeriod = new InternshipPeriod
                {
                    StartDate = DateTime.Today.AddMonths(+1),
                    EndDate = DateTime.Today.AddMonths(+2)
                };

                return internshipPeriod;
            }
        }

        #endregion

        #region Notifications
        static public Notification Notification1
        {
            get
            {
                var notif = new Notification()
                {
                    Time = new DateTime(2014, 02, 14),
                    Unseen = true,
                    LinkAction = "CoordinatorIndex",
                    LinkController = "InternshipOffer"
                };
                return notif;
            }
        }

        static public Notification Notification2
        {
            get
            {
                var notif = new Notification()
                {
                    Time = new DateTime(2014, 03, 15),
                    Unseen = false,
                    LinkAction = "CoordinatorIndex",
                    LinkController = "InternshipOffer"
                };
                return notif;
            }
        }
        #endregion
    }
}
