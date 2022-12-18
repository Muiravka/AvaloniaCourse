using coursach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursach.Views.CurrentUser
{
    public class CurrentUser
    {
        private static User? _user;
        public static User? currentUser
        {
            get => _user;
            set => _user = value;
        }
    }
}
