namespace ClientConfiguration.Infrastructure.SqlServer.Sql
{
    public class GetClientConfigByEligibilityClientConfigId
    {
        public const string Value = @"SELECT
                                        CES.ClientID,
                                        CES.ClientName,
                                        CES.CarrierID,
                                        CES.Carrier,
                                        CES.OrganizationKey,
                                        CES.TPA,
                                        CES.ChopperID,
                                        CES.SFTP,
                                        CES.EmailClients,
                                        CES.EmailInternal,
                                        CES.FTPLocation,
                                        CES.FileLocation,
                                        CES.FTPReceiveLocation,
                                        ECC.IsEligibilityFileAutomated,
                                        ECC.IsTranformationRequired,
                                        ECC.FileMask,
                                        ECC.DoStripHeader,
                                        ECC.EligibilityThresholdId,
                                        ECC.StagingFolder,
                                        ECC.ErrorFolder,
                                        ECC.CompletedFolder
                                    FROM DBO.ClientEligibilitySetup CES
                                    LEFT JOIN DBO.EligibilityClientConfiguration ECC ON CES.ClientID = ECC.ClientId
                                    WHERE ECC.EligibilityClientConfigurationId = @ID
                                    AND CES.IsDisabled = 0;";
    }
}
