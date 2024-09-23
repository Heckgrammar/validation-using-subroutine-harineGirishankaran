namespace ValidationTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstName, lastName, username, password, emailAddress;
            int age;

             // Get user input with validation
            {
                Console.Write("Enter first name: ");
                firstName = Console.ReadLine();

                while (!ValidName(firstName))
                {
                    Console.WriteLine("Invalid name. Please enter a valid first name.");
                    Console.Write("Enter first name: ");
                    firstName = Console.ReadLine();
                }


                Console.Write("Enter last name: ");
                lastName = Console.ReadLine();
                while (!ValidName(lastName))
                {
                    Console.WriteLine("Invalid name. Please enter a valid last name.");
                    Console.Write("Enter last name: ");
                    lastName = Console.ReadLine();
                }

                // Get age and validate

                Console.Write("Enter age: ");
                while (!int.TryParse(Console.ReadLine(), out age) || !ValidAge(age))
                {
                    Console.WriteLine("Invalid age. Age must be between 11 and 18.");
                    Console.Write("Enter age: ");
                }



                // Get password and validate
                Console.Write("Enter Password: ");
                password = Console.ReadLine();
                while (!ValidPassword(password))
                {
                    Console.WriteLine("Invalid password. It must contain at least 8 characters, including upper and lower case letters and non-letter characters.");
                    Console.Write("Enter Password: ");
                    password = Console.ReadLine();
                }
                // Get email and validate
                Console.Write("Enter email address: ");
                emailAddress = Console.ReadLine();
                while (!ValidEmail(emailAddress))
                {
                    Console.WriteLine("Invalid email. Please enter a valid email address.");
                    Console.Write("Enter email address: ");
                    emailAddress = Console.ReadLine();
                }

                // Create and display username
                username = CreateUserName(firstName, lastName, age);
                Console.WriteLine($"Username is {username}, you have successfully registered. Please remember your password.");
            }


            static bool ValidName(string name)
            {
                // Name must be at least two characters and contain only letters
                
            }

            static bool ValidAge(int age)
            {
                // Age must be between 11 and 18 inclusive
                
            }

            static bool ValidPassword(string password)
            {
                // Password must be at least 8 characters in length
                if (password.Length < 8)
                {
                    return false;
                }

                // Check if the password contains a mix of upper case, lower case, and non-letter characters
                bool hasUpper = password.Any(char.IsUpper);
                bool hasLower = password.Any(char.IsLower);
                bool hasNonLetter = password.Any(ch => !char.IsLetterOrDigit(ch));

                if (!hasUpper || !hasLower || !hasNonLetter)
                {
                    return false;
                }

                // Check for consecutive or repeating letters/numbers
                for (int i = 0; i < password.Length - 2; i++)
                {
                    if (password[i + 1] == password[i] && password[i + 2] == password[i])
                    {
                        return false; // more than 2 repeating characters
                    }

                    if ((password[i + 1] == password[i] + 1 && password[i + 2] == password[i] + 2) ||
                        (password[i + 1] == password[i] - 1 && password[i + 2] == password[i] - 2))
                    {
                        return false; // 3 consecutive characters
                    }
                }

                return true;
            }

            // QWErty%^& = valid
            // QWERTYUi = not valid
            // ab£$%^&* = not valid
            // QWERTYu! = valid

            static bool ValidEmail(string email)
            {
                // Check for a valid email structure
                if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
                {
                    return false;
                }
                     
                string[] emailParts = email.Split('@');                                                 
                if (emailParts.Length != 2 || emailParts[1].Split('.').Length < 2)     // has at least 2 characters followed by an @ symbol
                {
                    return false;
                }

                string domain = emailParts[1];
                if (domain.Length < 2 || domain.Split('.').Any(part => part.Length < 2))  // has at least 2 characters followed by a .
                {
                    return false;
                }

                return email.All(c => char.IsLetterOrDigit(c) || c == '@' || c == '.');    // has at least 2 characters after the .

            }

            static string CreateUserName(string firstName, string lastName, int age)
            {
                // Username is made up from:
                // First two characters of first name, last two characters of last name, and age
                return firstName.Substring(0, 2) + lastName.Substring(lastName.Length - 2) + age;


                //e.g. Bob Smith aged 34 would have the username Both34
            }
        }
    }
}
