using System;

namespace Stagio.Web
{
    public static class WebMessage
    {
        public static class GeneralMessage
        {
            public const string SIGN_IN = "Se connecter";
            public const string PASSWORD = "Mot de passe";
            public const string CURRENT_PASSWORD = "Mot de passe actuel";
            public const string NEW_PASSWORD = "Nouveau mot de passe";
            public const string EMAIL = "Courriel";
            public const string GENERAL_INFORMATIONS = "Informations générales";
            public const string CANCEL = "Annuler";
            public const string CONTACT_DETAILS = "Coordonnées";
            public const string SAVE_MODIFICATIONS = "Enregistrer les modifications";
            public const string NEXT = "Suivant";
            public const string SAVE = "Sauvegarder";
            public const string BACK = "Retour";
            public const string MY_STAGIO_ACCOUNT = "Mon compte Stagio";
            public const string CONFIRM = "Confirmer";
            public const string CONFIRMATION = "Confirmation";
            public const string CLOSE = "Fermer";
            public const string DELETE = "Supprimer";
            public const string DOWNLOAD = "Télécharger ";
            public const string EDIT = "Éditer";
            public const string MESSAGE = "Message";
            public const string RESUME = "Curriculum vitæ";
            public const string COVER_LETTER = "Lettre de présentation";
            public const string REQUIRED_FIELDS = "Les champs obligatoires sont marqués d'un astérisque. (*)";
        }

        public static class Layout
        {
            public const string STAGIO = "Stagio";
            public const string CARTEL = "Le Cartel de Progue";
            public const string MAFERLAND = "Marc-Antoine Ferland";
            public const string MAFORTIER = "Marc-Antoine Fortier";
            public const string OROY = "Olivier Roy";
            public const string RGAGNON = "Robin Gagnon";
            public const string FCHANDONNET = "Francis Chandonnet";
        }

        public static class Menus
        {
            public static class EmployeeMenu
            {
                public const string EDIT_COMPANY = "Modifier mon entreprise";
            }
            public static class CoordinatorMenu
            {
                public const string IMPORT_STUDENT_LIST = "Importer une liste d'étudiants";
                public const string STUDENT_LIST = "Liste des étudiants";
                public const string INVITE_COMPANIES = "Inviter les entreprises";
                public const string CHOOSE_PERIOD = "Choisir la période d'ouverture";
                public const string CLEAN_DATABASE = "Réinitialiser le système";
                public const string APPLICATION_INDEX = "Suivi des candidatures";
                public const string ARCHIVE = "Archives";
            }
            public static class StudentMenu
            {
                public const string INTERNSHIP_OFFERS = "Offres de stage";
            }

            public const string NOTIFICATIONS = "Notifications";
            public const string INTERNSHIP_OFFERS = "Offres de stage";
            public const string INTERNSHIP_APPLICATIONS = "Candidatures";
            public const string EDIT_PROFILE = "Modifier mon profil";
            public const string LOG_IN = "Se connecter";
            public const string LOG_OUT = "Se déconnecter";
        }

        public static class UserInformation
        {
            public const string ID = "Identifiant";
            public const string IDENTIFIER = "Matricule";
            public const string COMPLETE_NAME = "Nom complet";
            public const string FIRST_NAME = "Prénom";
            public const string LAST_NAME = "Nom";
            public const string PHONE_NUMBER = "Téléphone";
            public const string EXTENSION_NUMBER = "Numéro de poste";
            public const string EXTENTION = "Poste";
            public const string FUNCTION = "Titre / Fonction";
        }
        public static class HomeMessage
        {
            public const string SYSTEM_IS_NOT_OPEN = "Le système est présentement fermé. Il sera ouvert à la prochaine période de stage.";
            public const string WELCOME = "Bienvenue sur";
            public const string WELCOMING_MESSAGE_PART_1 = "Outil de suivi des stages en informatique";
            public const string WELCOMING_MESSAGE_PART_2 = "du Cégep de Sainte-Foy";
            public const string COMPANY = "Entreprise";
            public const string STUDENT = "Étudiant";
            public const string SUBSCRIPTION = "Inscription";
            public const string SUBSCRIBE = "S'inscrire à Stagio";
            public const string SUBSCRIBE_AS_STUDENT = "Inscription en tant qu'étudiant";
        }

        public static class AccountMessage
        {
            public const string INVALID_USERNAME_OR_PASSWORD = "Utilisateur ou mot de passe inexistant";
            public const string SYSTEM_IS_NOT_OPEN = "Le système est présentement fermé.";
            public const string CONNECT_TO_STAGIO = "Connectez-vous à votre compte Stagio";
            public const string HAVE_NO_ACCOUNT = "Vous n'avez pas de compte?";
            public const string SIGN_UP_HERE = "Inscrivez-vous ici";
        }

        public static class StudentMessage
        {
            public const string SUBSCRIBE_IDENTIFIER_NOT_FOUND = "Matricule invalide, veuillez contacter le coordonnateur des stages.";
            public const string ACCOUNT_CREATE_SUCCESS = "Votre compte étudiant a été créé avec succès!";
            public const string PROFILE_CREATION_TITLE = "Création du profil";
            public const string STUDENT = "Étudiant";
            public const string PERSONAL_INFOS = "Informations personnelles";
            public const string EDIT_PROFILE = "Modifier mon profil";
            public const string MY_APPLICATIONS = "Mes candidatures de stage";
        }

        public static class EmployeeMessage
        {
            public const string IDENTIFIER_ALREADY_USED = "Cet identifiant est déjà utilisé.";
            public const string ACCOUNT_CREATE_SUCCESS = "Votre compte employé a été créé avec succès!";
            public const string COMPANY_PROFILE_EDIT_SUCCESS = "Le profil de votre compagnie a été modifié avec succès.";
            public const string CREATE_ACCOUNT_TITLE = "Création d'un compte Stagio pour un employé d'une entreprise";
            public const string CREATE_ACCOUNT = "Créer le compte";
            public const string EDIT_PROFILE_TITLE = "Modifier mon profil";
            public const string SEE_APPLICATIONS = "Voir toutes les candidatures";
            public const string CREATE_INTERNSHIP_OFFER = "Créer une offre de stage";
            public const string SEE_OFFERS = "Voir toutes les offres de stage";
            public const string VALIDATING_OFFERS = "Offres en validation";
        }

        public static class CoordinatorMessage
        {
            public static class CleanDatabase
            {
                public const string CLEAN_DATABASE = "Réinitialiser le système";
                public const string CLEAN = "Réinitialiser";
                public const string CONFIRMATION = "Confirmation";
                public const string CLOSE = "Fermer";
                public const string CLEAN_DATABASE_SUCCESS = "Le système a été remis à zéro.";
                public const string CLEAN_DATABASE_VALIDATION = "Cette action est irréversible";
            }
            public static class ChoosePeriod
            {
                public const string START = "Début";
                public const string END = "Fin";
                public const string CHOOSE_DATE_SUCCESS = "Les dates de début et de fin de la période d'ouverture du système ont été sauvegardées.";
                public const string INVALID_START_DATE = "La date de début ne peut pas être après la date de fin.";
                public const string CHOOSE_PERIOD_TITLE = "Choisir la période d'ouverture du système";
                public const string CHOOSE_PERIOD_SUBTITLE = "Choisir une période d'ouverture du système permettera de bloquer l'accès au système par les employés et les étudiants";
                public const string CHOOSE_DATES = "Choisir les dates d'ouverture et de fermeture du système";

                public static string LAST_CHOSEN_PERIOD(string startingDate, string endingDate)
                {
                    return "Dernière période d'ouverture du système choisie: Du " + startingDate + " au " + endingDate;
                }
            }
            public static class InviteCompanies
            {
                public const string TITLE = "Inviter les entreprises à s'inscrire au système";
                public const string SEND_MESSAGE = "Envoyer un message aux entreprises";
                public const string SEND_INVITATIONS = "Envoyer les invitations";
                public const string OBJECT = "Sujet";
                public const string MESSAGE = "Message";
            }

            public static class ImportStudents
            {
                public const string TITLE = "Importer une liste d'étudiants";
                public const string SELECT_FILE = "Sélectionner un fichier";
            }

            public const string CONFIRM_PASSWORD_MESSAGE = "Veuillez confirmer votre mot de passe.";
            public const string WRONG_PASSWORD_VALIDATION = "Mot de passe invalide";
            public const string STUDENT_ACCOUNTS_IMPORT_SUCCESS = "Les comptes étudiants on été créés avec succès.";
            public const string STUDENT_LIST = "Liste des étudiants";
            public const string VALIDATE_IMPORT = "Valider l'importation";
            public const string DATA_TO_IMPORT = "Données à importer";
            public const string IMPORT_STUDENT_ACCOUNTS = "Importer les comptes étudiants";
            public const string APPLICATION_PROGRESSION = "Suivi des candidatures";
            public const string STUDENT_APPLICATION_DATE = "L'étudiant a postulé le";
            public const string SEE_APPLICATIONS = "Voir toutes les candidatures";
            public const string STUDENT_APPLICATIONS = "Candidatures de l'étudiant";
            
            public static string TOTAL_STUDENT(int number)
            {
                return number + " étudiant(s) au total";
            }

            public static string SUBSCRIBED_STUDENTS(int number)
            {
                return number + " inscrit(s)";
            }

            public static string UNSUBSCRIBED_STUDENTS(int number)
            {
                return number + " non-inscrit(s)";
            }

            public static string STUDENTS_COUNT(int number)
            {
                return number + " étudiant(s)";
            }
        }

        public static class CompanyMessage
        {
            public const string NAME = "Nom";
            public const string ADDRESS = "Adresse";
            public const string TELEPHONE = "Téléphone";
            public const string EMAIL = "Adresse courriel";
            public const string WEBSITE = "Site web";
            public const string CHOOSE_COMPANY = "Choisir son entreprise";
            public const string YOUR_COMPANY_IS = "Votre entreprise est ...";
            public const string NAME_ALREADY_USED = "Cette entreprise existe déjà";
            public const string NEW_COMPANY = "Nouvelle entreprise...";
            public const string SELECT_YOUR_COMPANY = "Sélectionnez votre entreprise";
            public const string INFO_CREATE_NEW_COMPANY = "Si votre entreprise ne se trouve pas dans la liste, veuillez sélectionner \"Nouvelle entreprise\" afin de la créer.";
            public const string CREATE_YOUR_COMPANY = "Créer son entreprise";
            public const string CREATE_THE_COMPANY = "Créer l'entreprise";
            public const string EDIT_COMPANY_PROFILE = "Modifier le profil de l'entreprise";
        }

        public static class InternshipOfferMessage
        {
            public const string OFFER_TITLE = "Titre de l'offre";
            public const string INTERNSHIP_TITLE = "Titre du stage";
            public const string REQUIRED_INTERNSHIP_TITLE = "Titre du stage *";
            public const string DRAFT_DELETED_SUCCESS = "Le brouillon a été supprimé avec succès.";
            public const string DENY_OFFER_MAIL_SUBJECT = "Stagio - Une de vos offres de stage vient d'être refusée.";
            public const string BODY_IS_REQUIRED = "Veuillez inscrire la raison du refus de l'offre.";
            public const string GENERIC_DENY_ERROR = "Une erreur s'est produite lors du processus de refus de l'offre. Veuillez réessayer.";
            public const string OFFER_DENIED_SUCCESS = "L'offre a bien été refusée et un message a été envoyé à l'employé ayant créé cette offre.";
            public const string OFFER_ACCEPTED_SUCCESS = "L'offre a été acceptée et est maintenant visible pour tous les étudiants.";
            public const string OFFER_CREATED_SUCCESS = "L'offre de stage a été envoyée au coordonnateur pour la validation.";
            public const string OFFER_DRAFT_SUCCESS = "Le brouillon de l'offre de stage a été sauvegardé avec succès.";

            public const string REQUIRED_TITLE = "Votre offre de stage doit avoir un titre.";
            public const string REQUIRED_CONTACT = "Votre offre de stage doit avoir un responsable.";
            public const string REQUIRED_DESCRIPTION = "Votre offre de stage doit avoir une description.";
            public const string REQUIRED_DETAILS = "Ces détails sont requis.";
            public const string REQUIRED_PERSON_IN_CHARGE = "Ces informations sont requises.";

            public const string DRAFT_DELETE_VALIDATION_MESSAGE = "Êtes-vous certain de vouloir suprimer le brouillon?";

            public const string SEE_COMPLETE_OFFER = "Voir l'offre complète";

            public const string OFFERS_ON_VALIDATION = "En validation";
            public const string OFFERS_ON_VALIDATION_COMPLETE = "Offres en validation";
            public const string OFFERS_TO_VALIDATE = "À valider";
            public const string REFUSED_OFFERS = "Refusées";
            public const string REFUSED_OFFERS_COMPLETE = "Offres refusées";
            public const string PUBLICATED_OFFERS = "Publiées";
            public const string PUBLICATED_OFFERS_COMPLETE = "Offres publiées";
            public const string DRAFT_OFFERS = "Brouillons";
            public const string APPLY = "Postuler";
            public const string PUBLICATION_DATE = "Date de publication";

            public const string INTERNSHIP_INFORMATIONS = "Informations sur le stage";
            public const string COMPANY_INFORMATIONS_NOTICE = "Les informations complètes de l'entreprise seront affichées dans l'offre de stage.";

            public static class OfferCreation
            {
                public const string TITLE = "Création d'une offre de stage";
                public const string INTERNSHIP_INFORMATIONS = "Informations sur le stage";
                public const string COMPANY_INFORMATIONS_NOTICE = "Les informations complètes de l'entreprise seront affichées dans l'offre de stage.";
                public const string EXTRA_FILE_NOTICE = "Vous pouvez téléverser un fichier informatif supplémentaire concernant le stage. (10 Mo. maximum)";
                public const string VALIDATION_NOTICE = "Votre offre de stage devra être validée par le coordonnateur avant d'être publiée sur le site.";
                public const string DELETE_OFFER_NOTICE = "Afin de retirer une offre de stage, veuillez contacter le responsable des stages.";
                public const string SEND_OFFER = "Publier l'offre de stage";
                public const string SAVE_DRAFT = "Enregistrer le brouillon";
                public const string DELETE_DRAFT = "Supprimer le brouillon";
                public const string COMPANY = "Entreprise ou organisation";
                public const string OTHER_CONTACT = "Autre contact pour le stage";
                public const string EXTRA_FILE = "Fichier supplémentaire";
                public const string CONTACT = "Responsable du stage";
                public const string DESCRIPTION = "Description du projet pour le stage";
                public const string DETAILS = "Détails spécifiques au stage";
                public const string NUMBER_OF_TRAINEES = "Nombre de stagiaires";
                public const string PERSON_IN_CHARGE = "Soumettre les candidatures à";
                public const string DEADLINE = "Date limite pour soumettre les candidatures";
                public const string REQUIRED_CONTACT = "Responsable du stage *";
                public const string REQUIRED_DESCRIPTION = "Description du projet pour le stage *";
                public const string REQUIRED_DETAILS = "Détails spécifiques au stage *";
                public const string REQUIRED_NUMBER_OF_TRAINEES = "Nombre de stagiaires *";
                public const string REQUIRED_PERSON_IN_CHARGE = "Soumettre les candidatures à *";
                public const string REQUIRED_DEADLINE = "Date limite pour soumettre les candidatures *";
            }

            public static class OfferDetails
            {
                public const string TITLE = "Détails de l'offre de stage";
                public const string BASIC_INFOS = "Informations de base";
                public const string DENY_MESSAGE = "Message de refus";
                public const string DENY_REASONS = "Veuillez entrer la ou les raison(s) du refus";
                public const string REFUSE_OFFER = "Refuser l'offre";
                public const string ACCEPT = "Accepter";
                public const string REFUSE = "Refuser";
                public const string REQUIRED_SOFTWARE_HARDWARE = "Environnement matériel et logiciel *";
                public const string REQUIRED_SCHEDULE = "Horaire *";
                public const string REQUIRED_HOURS_PER_WEEK = "Nombre d'heures de travail par semaine *";
                public const string REQUIRED_WAGE = "Salaire horaire *";
                public const string SOFTWARE_HARDWARE = "Environnement matériel et logiciel";
                public const string SCHEDULE = "Horaire";
                public const string HOURS_PER_WEEK = "Nombre d'heures de travail par semaine";
                public const string WAGE = "Salaire horaire";
            }

            public static class OfferIndex
            {
                public const string COORDINATOR_TITLE = "Offres de stage";
                public const string EMPLOYEE_TITLE = "Offres de stage pour mon entreprise";
                public const string STUDENT_TITLE = "Offres de stage disponibles";
            }

            public static string OFFERS_COUNT(int number)
            {
                return number + " offre(s) de stage";
            }
        }

        public static class InternshipPeriodMessage
        {
            public const string STUDENTS_COUNT = "Nombre total d'étudiants inscrits";
            public const string STUDENTS_WITH_INTERNSHIP_COUNT = "Nombre d'étudiants ayant obtenu un stage";
            public const string STUDENTS_WITHOUT_INTERNSHIP_COUNT = "Nombre d'étudiants n'ayant pas obtenu de stage";
            public const string EMPLOYEES_COUNT = "Nombre total d'employées inscrits";
            public const string COMPANIES_COUNT = "Nombre total de compagnies inscrites";
            public const string INTERNSHIP_OFFERS_COUNT = "Nombre total d'offres de stage publiées";
            public const string INTERVIEWS_COUNT = "Nombre total d'entrevues ayant eu lieu";
            public const string INTERNSHIP_APPLICATIONS_COUNT = "Nombre total d'applications sur les offres de stage par les étudiants";
            public const string COMPANY_OFFERS_COUNT = "Nombre total d'acceptations d'un étudiant par une compagnie après l'entrevue";
            public const string START_DATE = "Date de début de la période de stage";
            public const string END_DATE = "Date de fin de la période de stage";
        }

        public static class InviteCompaniesMessage
        {
            public const string GENERIC_INVITE_COMPANIES_ERROR = "Une erreur s'est produite lors du processus d'envoi des messages. Veuillez réessayer.";
            public const string INVITE_COMPANIES_SUCCES = "Toutes les entreprises inscrites dans le système ont été contactées.";
        }

        public static class InternshipApplicationMessage
        {
            public const string NO_APPLICATION_FOR_THIS_STUDENT = "Cet étudiant n'a appliqué sur aucune offre.";
            public const string APPLICATION_CREATE_SUCCESS = "Vous avez postulez avec succès!";
            public const string APPLICATION_PROGRESSION_UPDATE_SUCCESS = "La progression de votre candidature a été mise à jour!";
            public const string SEE_APPLICATIONS = "Voir les candidatures";
            public const string TOTAL_APPLICATIONS = "Candidatures au total";
            public const string APPLICATION_DATE = "Date de postulation";
            public static class StudentHasApplied
            {
                public const string PROGRESSION = "Progression";
                public const string PROGRESSION_DESCRIPTION = "En attente d'une entrevue...";
                public const string PROGRESSION_UPDATE_HTML_CONTENT = "Je confirme avoir passé une entrevue avec l'entreprise en date du ";
                public const string PROGRESSION_UPDATE_HTML_TITLE = "Confirmation de votre présence à l'entrevue";
                public const string PROGRESSION_UPDATE_DATE_TEXT = "Vous avez postulé le ";
                public const string LAST_UPDATE = "Dernière mise à jour";
            }

            public static class StudentHadInterview
            {
                public const string PROGRESSION_DESCRIPTION = "En attente du résultat de l'entrevue...";
                public const string PROGRESSION_UPDATE_HTML_CONTENT = "Je confirme avoir été sélectionné pour le stage en date du ";
                public const string PROGRESSION_UPDATE_HTML_TITLE = "Confirmation de votre sélection pour le stage";
                public const string PROGRESSION_UPDATE_DATE_TEXT = "Vous avez passé l'entrevue le ";
            }

            public static class CompanyAcceptedStudent
            {
                public const string PROGRESSION_DESCRIPTION = "Veuillez confirmer votre adhésion au stage.";
                public const string PROGRESSION_UPDATE_HTML_CONTENT = "Je confirme avoir accepté le poste de stagiaire en date du ";
                public const string PROGRESSION_UPDATE_HTML_TITLE = "Confirmation de votre adhésion au stage";
                public const string PROGRESSION_UPDATE_DATE_TEXT = "Vous avez été sélectionné le ";
            }

            public static class StudentAcceptedOffer
            {
                public const string PROGRESSION_DESCRIPTION = "Vous avez été accepté pour le stage!";
                public const string PROGRESSION_UPDATE_HTML_CONTENT = "";
                public const string PROGRESSION_UPDATE_HTML_TITLE = "";
                public const string PROGRESSION_UPDATE_DATE_TEXT = "Vous avez accepté le poste le ";
                //Le cas StudentAcceptedOffer n'a pas de prochaine étape, d'où les chaines vides
            }

            public static class StudentCreateOffer
            {
                public const string APPLY_TO_INTERNSHIP = "Postuler pour un stage";
                public const string UPLOAD_YOUR_FILES = "Téléversez vos fichiers";
            }

            public static class CompanyViewsApplications
            {
                public const string OFFER_APPLICATIONS = "Candidatures pour l'offre de stage";
            }
            public static string APPLICATIONS_COUNT(int number)
            {
                return number + " candidature(s)";
            }
            public static string COMPLETION_BAR(string percentage)
            {
                return percentage + " complété (success)";
            }
            public static string COMPLETION(string percentage)
            {
                return percentage + "% complété";
            }
        }

        public static class GlobalMessage
        {
            public const string NOT_APPLICABLE = "N/A";
            public const string EMAIL_ALREADY_USED = "Cette adresse courriel est déjà utilisée par un autre utilisateur.";
            public const string PROFILE_EDIT_SUCCESS = "Votre profil a été modifié avec succès.";
            public const string PASSWORD_EDIT_SUCCESS = "Votre mot de passe a été modifié avec succès.";

        }

        public static class DataFormat
        {
            public const string PHONE_NUMBER_FORMAT = "Format attendu : (555)-555-5555";
            public const string WEBSITE_URL_FORMAT = "Format attendu : http://stagio.com";
            public const string DATE_FORMAT = "{0:yyyy-MM-dd}";
            public const string DRAFT_DELETE_VALIDATION_MESSAGE = "Êtes-vous certain de vouloir supprimer le brouillon?";
        }

        public static class ErrorMessage
        {
            public const string FILE_NOT_FOUND = "Impossible de trouver le fichier, veuillez contacter l'administrateur.";
            public const string INVALID_FILE_DATA = "Les données du fichier sont invalides.";
            public const string INVALID_FILE_FORMAT = "Format de fichier invalide. Format accepté : ";
            public const string INVALID_FILE_SIZE = "La taille maximale du fichier est de {0} bytes";
            public const string INVALID_DATE_FORMAT = "Le format de la date est invalide.";

            public const string INVALID_PHONE_NUMBER_FORMAT = "Le numéro de téléphone est incomplet ou n'a pas le bon format (" + WebMessage.DataFormat.PHONE_NUMBER_FORMAT + ").";
            public const string INVALID_EXTENSION_NUMBER_FORMAT = "Le numéro de poste est invalide.";
            public const string INVALID_URL_FORMAT = "L'url est invalide ou n'a pas le bon format (" + WebMessage.DataFormat.WEBSITE_URL_FORMAT + ").";
            public const string INVALID_EMAIL_FORMAT = "Le format de l'adresse courriel est invalide.";
            public const string INVALID_IDENTIFIER_FORMAT = "Le matricule est invalide.";

            public const string INVALID_PASSWORD_LENGTH = "Le nouveau mot de passe doit contenir au moins {2} caractères.";
            public const string INVALID_PASSWORD_FORMAT = "Le nouveau mot de passe doit contenir au moins 2 chiffres et 2 lettres.";
            public const string INVALID_PASSWORD_CORRESPONDENCE = "La confirmation du mot de passe ne correspond pas.";
        }

        public static class RequiredFieldMessage
        {
            public const string REQUIRED_IDENTIFIER = "Votre identifiant est requis.";
            public const string REQUIRED_PASSWORD = "Votre mot de passe est requis.";
        }

        public static class RegularExpression
        {
            public const string PHONE_NUMBER_FORMAT = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        }

        public static class NotificationMessage
        {
            public static string NewInternshipOfferCreatedMessage(string company, string employee)
            {
                return employee + " de " + company + "  a ajouté une nouvelle offre de stage.";
            }

            public const string NO_NOTIFICATION_MESSAGE = "Aucune notification pour l'instant.";
        }
    }
}