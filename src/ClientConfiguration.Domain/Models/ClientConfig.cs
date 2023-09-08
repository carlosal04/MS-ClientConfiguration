namespace ClientConfiguration.Domain.Models
{
    public class ClientConfig
    {
        public long ClientId { get; set; }
        public string ClientName { get; set; }
        public string CarrierId { get; set; }
        public string Carrier { get; set; }
        public string OrganizationKey { get; set; }
        public string TPA { get; set; }
        public long ChopperId { get; set; }
        public bool SFTP { get; set; }
        public string EmailClients { get; set; }
        public string EmailInternal { get; set; }
        public string FTPLocation { get; set; }
        public string FileLocation { get; set; }
        public string FTPReceiveLocation { get; set; }
        public bool IsEligibilityFileAutomated { get; set; }
        public bool IsTranformationRequired { get; set; }
        public string FileMask { get; set; }
        public bool DoStripHeader { get; set; }
        public long EligibilityThresholdId { get; set; }
        public string StagingFolder { get; set; }
        public string ErrorFolder { get; set; }
        public string CompletedFolder { get; set; }
    }
}
