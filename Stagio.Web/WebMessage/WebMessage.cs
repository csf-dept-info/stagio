using System;

namespace Stagio.Web
{
    public static class WebMessage
    {
        public static class GeneralMessage
        {
            public const string SIGN_IN = "Se connecter";
            public const string PASSWORD = "Mot de passe";
            public const string EMAIL = "Courriel";
            public const string GENERAL_INFORMATIONS = "Informations générales";
            public const string CANCEL = "Annuler";
            public const string CONTACT_DETAILS = "Coordonnées";
            public const string SAVE_MODIFICATIONS = "Enregistrer les modifications";
            public const string NEXT = "Suivant";
            public const string SAVE = "Sauvegarder";
            public const string BACK = "Retour";
            public const string MY_STAGIO_ACCOUNT = "Mon compte Stagio";
        }

        public static class UserInformation
        {
            public const string IDENTIFIER = "Matricule";
            public const string FIRST_NAME = "Prénom";
            public const string LAST_NAME = "Nom";
        }
        public static class HomeMessage
        {
            public const string SYSTEM_IS_NOT_OPEN = "Le système est présentement fermé. Il sera ouvert à la prochaine période de stage.";
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
                public const string CONFIRM = "Confirmer";
                public const string CONFIRMATION = "Confirmation";
                public const string CLOSE = "Fermer";
                public const string CLEAN_DATABASE_SUCCESS = "Le système a été remis à zéro.";
                public const string CLEAN_DATABASE_VALIDATION = "Cette action est irréversible";
            }
            public static class ChoosePeriod
            {
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
            public const string CONFIRM_PASSWORD_MESSAGE = "Veuillez confirmer votre mot de passe.";
            public const string WRONG_PASSWORD_VALIDATION = "Mot de passe invalide";
            public const string STUDENT_ACCOUNTS_IMPORT_SUCCESS = "Les comptes étudiants on été créés avec succès.";
            public const string STUDENT_LIST = "Liste des étudiants";
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

            public static string VALIDATE_IMPORT = "Valider l'importation";
            public static string DATA_TO_IMPORT = "Données à importer";
            public static string IMPORT_STUDENT_ACCOUNTS = "Importer les comptes étudiants";
        }

        public static class CompanyMessage
        {
            public const string CHOOSE_COMPANY = "Choisir son entreprise";
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
            public static class StudentHasApplied
            {
                public const string PROGRESSION_DESCRIPTION = "En attente d'une entrevue...";
                public const string PROGRESSION_UPDATE_HTML_CONTENT = "Je confirme avoir passé une entrevue avec l'entreprise en date du ";
                public const string PROGRESSION_UPDATE_HTML_TITLE = "Confirmation de votre présence à l'entrevue";
                public const string PROGRESSION_UPDATE_DATE_TEXT = "Vous avez postulé le ";
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