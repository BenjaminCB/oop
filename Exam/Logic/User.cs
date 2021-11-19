using System;
using System.Linq;
using System.Text.RegularExpressions;
using Exam.Exception;

namespace Exam.Logic
{
    public class User : IComparable<User>
    {
        // even though there is an id column in the csv files it seems ilogical
        // to use them as human error is going to occur at some point
        // assignment using a static variable makes sure that does not happen
        public int Id { get; }
        private static int _Id = 1;

        public string Firstname { get; }
        public string Lastname { get; }

        // can only have 0-9 a-z and '_'
        public string Username { get; }
        private Regex _UsernameValidator = new Regex(@"^[a-z0-9_]+$");


        // must follow local-part@domain where
        // local-part can be a-z A-Z 0-9 and '.' '_' '-'
        // domain can be a-z A-Z 0-9 and '.' '-' cannot start/end with '.' or '-'
        // and should have at least one '.'
        public string Email { get; }

        // [\w.-]+ capture atleast one letter number or .-_
        // ([^\W-])+ capture at least one letter or number
        // (\.([^\W_]|[.-])+)+ capture at least one . followed by atleast one
        // letter number or .-
        // TODO check correctness
        private Regex _EmailValidator =
            new Regex(@"^[\w.-]+@([^\W_])+-*(\.([^\W_]|[.-])+)+([^\W_])+$");

        public int Balance { get; set; }

        public User(string fullname, string username, string email)
            : this(fullname, username, 0, email) {}

        public User(string fullname, string username, int balance, string email)
        {
            Id = _Id++;

            // split fullname into individual names and distribute them
            string[] names = fullname.Split(' ');
            Firstname = String.Join(' ', names.Take(names.Length - 1));
            Lastname = names.Last();

            // validate username
            if (!_UsernameValidator.IsMatch(username))
                throw new InvalidUsernameException();
            Username = username;

            Balance = balance;

            // validate email
            if (!_EmailValidator.IsMatch(email))
                throw new InvalidEmailException();
            Email = email;
        }

        // smaller id should preceed bigger id
        public int CompareTo(User other) => this.Id - other.Id;

        public override string ToString() => $"{Firstname} {Lastname} ({Email})";

        // first check if obj is defined and is of type User
        // then check equality by Id
        public override bool Equals(object obj) =>
            obj != null && obj is User && ((User) obj).Id == this.Id;

        // every id is unique
        public override int GetHashCode() => Id;
    }
}
