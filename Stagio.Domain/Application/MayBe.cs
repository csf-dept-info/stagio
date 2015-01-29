using System.Collections;
using System.Collections.Generic;

namespace Stagio.Domain.Application
{
    // Classe générique qui permet d'éviter de retourner Null. 
    //
    // Exemple d'utilisation:
    // La méthode Validate ci-dessous doit déterminer si un utilisateur est valide ou non. Elle retourne un MayBe<ApplicationUser>.
    // Si l'utilisateur est valide, le premier élément du IEnumerable est cet utilisateur.
    // Si l'utilisateur est non-valide, le retour est une Ienumerable vide
    //
    //     var user = _validationUserService.Validate(accountLoginViewModel.Email, accountLoginViewModel.Password);
    //


    public class MayBe<T> : IEnumerable<T>
    {

        // Selon le constrcuteur appelée, _value peut contenir aucun élément ou 1 seul élément
        private readonly IEnumerable<T> _values;

        public MayBe()
        {
            _values = new T[0];
        }

        public MayBe(T value)
        {
            _values = new[] { value };
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
