namespace SDPCloud.IdentityServer.Quickstart.OurStuff
{
    public interface IOurUserRepository
    {
        bool ValidateCredentials(string username, string password);

        OurCustomUser FindBySubjectId(string subjectId);

        OurCustomUser FindByUsername(string username);
    }
}