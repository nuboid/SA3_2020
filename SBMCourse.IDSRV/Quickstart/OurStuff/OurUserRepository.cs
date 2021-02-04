using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDPCloud.IdentityServer.Quickstart.OurStuff
{
    public class OurUserRepository : IOurUserRepository
    {

        private readonly List<OurCustomUser> _users = new List<OurCustomUser> {
            new OurCustomUser
                {
                    UserName = "Bob",
                    SubjectId = "subjectid_bob",
                    Email = "bob@sdpcloud.com"
                } ,
                          new OurCustomUser
                {
                    UserName = "Alice",
                      SubjectId = "subjectid_alice",
                    Email = "bob@sdpcloud.com"
                }
        };

        public bool ValidateCredentials(string username, string password)
        {
            //var user = FindByUsername(username);
            //if (user != null)
            //{
            //    return user.Password.Equals(password);
            //}
            if (password == "Please")
            {
                return true;
            }
            return false;
        }

        public OurCustomUser FindBySubjectId(string subjectId)
        {
            return _users.FirstOrDefault(x => x.SubjectId == subjectId);
        }

        public OurCustomUser FindByUsername(string username)
        {
            return _users.FirstOrDefault(x => x.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        }


    }


}
