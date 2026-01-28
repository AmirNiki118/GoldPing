using GoldAlert.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldAlert.Domain.Users
{
    public class User : BaseEntity
    {
        public string Mobile { get; private set; }
        public bool IsActive { get; private set; }

        private User() { }

        public User(string mobile)
        {
            if (string.IsNullOrWhiteSpace(mobile))
                throw new ArgumentException("Mobile is required");

            Mobile = mobile;
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
