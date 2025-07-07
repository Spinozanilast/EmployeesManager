using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Permissions.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "permissions",
                table: "permissions",
                columns: new[] { "id", "category", "description", "name" },
                values: new object[,]
                {
                    { new Guid("008542dd-0678-42d1-a5b4-296d411fb3cb"), "Reporting", "Audit capability for Revoke operations on Reporting user profiles", "Reporting.Revoke" },
                    { new Guid("00926377-e008-44e0-b170-9d413b34a72c"), "Reporting", "Limited scope for Lock operations on Reporting configuration settings", "Reporting.Lock" },
                    { new Guid("00b32205-fd18-4916-925e-1c2dbb3e888b"), "Reporting", "Security-restricted Unlock operations on Reporting workflow definitions", "Reporting.Unlock" },
                    { new Guid("0161cbc9-1821-409e-a4f7-e09a0744905b"), "Integration", "Compliance-related access to Schedule operations on Integration API endpoints", "Integration.Schedule" },
                    { new Guid("02385c80-7f3d-4f86-b338-de6e4e14834d"), "Security", "Temporary permission to Create operations on Security security policies", "Security.Create" },
                    { new Guid("02423287-f75a-4bdb-84ce-fbaf5744efd8"), "Audit", "Security-restricted Reject operations on Audit sensitive data", "Audit.Reject" },
                    { new Guid("024a5e59-f9c1-4154-949b-eedb6888d406"), "API", "Administrative control over Edit operations on API security policies", "API.Edit" },
                    { new Guid("0767faa4-cb31-4300-b1db-56ffc3c91f8a"), "Reporting", "Global access to Schedule operations on Reporting reporting modules", "Reporting.Schedule" },
                    { new Guid("07e37905-6a91-4f67-bac9-d78286f63d4a"), "DataAccess", "Temporary permission to Execute operations on DataAccess sensitive data", "DataAccess.Execute" },
                    { new Guid("089bd578-93ad-4dac-8fe1-6e7b67d7223d"), "Integration", "Emergency access to Create operations on Integration security policies", "Integration.Create" },
                    { new Guid("08d6cd29-12db-4307-b444-f8c816d10d0b"), "API", "Compliance-related access to Reject operations on API user profiles", "API.Reject" },
                    { new Guid("0b4ee39f-d63d-4b64-a105-7cd71b13c9d0"), "API", "Limited scope for Monitor operations on API security policies", "API.Monitor" },
                    { new Guid("0b5573c9-a4bd-427e-9a6d-fdabd2fd95cc"), "Reporting", "Limited scope for Bypass operations on Reporting integration pipelines", "Reporting.Bypass" },
                    { new Guid("0cbd47b8-e0ad-4978-b345-714a21118719"), "DataAccess", "Audit capability for Edit operations on DataAccess API endpoints", "DataAccess.Edit" },
                    { new Guid("0ce6bb6a-c7d2-4072-a344-464ef8ea9120"), "Reporting", "Administrative control over Execute operations on Reporting security policies", "Reporting.Execute" },
                    { new Guid("0fc3bdc8-b731-4337-9c8d-fa6ccbe2c02a"), "API", "Limited scope for Grant operations on API integration pipelines", "API.Grant" },
                    { new Guid("1006f736-a698-4644-aad4-02668bf75534"), "SystemConfig", "Approval workflow covering Reject operations on SystemConfig audit logs", "SystemConfig.Reject" },
                    { new Guid("10517cf6-b644-4e78-8973-b449866fd84a"), "Integration", "Temporary permission to Restore operations on Integration reporting modules", "Integration.Restore" },
                    { new Guid("12e26c5b-47b4-4d86-8407-1519c97313dc"), "RoleManagement", "Emergency access to Edit operations on RoleManagement user profiles", "RoleManagement.Edit" },
                    { new Guid("1345bab8-7d18-451a-844b-1c7d84ba84c9"), "Reporting", "Delegated authority for Reject operations on Reporting workflow definitions", "Reporting.Reject" },
                    { new Guid("13b0cfc3-73fc-418d-95f3-1c7dd95ad34d"), "Integration", "Temporary permission to Reject operations on Integration system resources", "Integration.Reject" },
                    { new Guid("14b1c343-d222-4dec-9968-bbc36cf1f0b5"), "RoleManagement", "Global access to Archive operations on RoleManagement user profiles", "RoleManagement.Archive" },
                    { new Guid("1816758c-4cb5-49b5-8d3a-798090dbabb8"), "UserManagement", "Delegated authority for Grant operations on UserManagement security policies", "UserManagement.Grant" },
                    { new Guid("19b04961-1eb1-4bd0-aa65-992d079cd21e"), "Workflow", "Compliance-related access to View operations on Workflow audit logs", "Workflow.View" },
                    { new Guid("1b6cb8e3-3a48-4502-a0c6-e7b5795dbaf2"), "Audit", "Delegated authority for Archive operations on Audit workflow definitions", "Audit.Archive" },
                    { new Guid("1c92b10a-7497-412a-9e79-10407e117bff"), "RoleManagement", "Compliance-related access to Revoke operations on RoleManagement sensitive data", "RoleManagement.Revoke" },
                    { new Guid("1d5ca28d-3172-472a-a4ce-9c94c20d3b71"), "RoleManagement", "Audit capability for Create operations on RoleManagement user profiles", "RoleManagement.Create" },
                    { new Guid("1dd7b85d-77d3-43ae-b992-a5f635dec756"), "Security", "Audit capability for Reject operations on Security user profiles", "Security.Reject" },
                    { new Guid("1e9f0884-ff3f-4dc4-b264-4d40722c601d"), "RoleManagement", "Security-restricted Grant operations on RoleManagement integration pipelines", "RoleManagement.Grant" },
                    { new Guid("1f51def2-0982-4d0a-9a15-28c9c94126aa"), "RoleManagement", "Audit capability for View operations on RoleManagement integration pipelines", "RoleManagement.View" },
                    { new Guid("20c91abd-9dd0-4712-8f4c-33be0954d7d4"), "Audit", "Temporary permission to Delegate operations on Audit sensitive data", "Audit.Delegate" },
                    { new Guid("20e98afc-b6b0-4c27-b416-ce8de2995c38"), "SystemConfig", "Compliance-related access to View operations on SystemConfig audit logs", "SystemConfig.View" },
                    { new Guid("20face18-4a30-4272-8621-40f21ebadec2"), "UserManagement", "Global access to Reject operations on UserManagement reporting modules", "UserManagement.Reject" },
                    { new Guid("2222821d-02d6-4755-bb94-a3781b652090"), "Integration", "Emergency access to Import operations on Integration audit logs", "Integration.Import" },
                    { new Guid("2335fb33-d2e9-48ca-86ac-44c6a550f8b4"), "Audit", "Global access to Delete operations on Audit configuration settings", "Audit.Delete" },
                    { new Guid("23411b0c-59a9-44b2-9ab1-fc3e733ba14a"), "Audit", "Audit capability for Revoke operations on Audit sensitive data", "Audit.Revoke" },
                    { new Guid("23fb4d21-7501-40d8-8501-6e70989ecbda"), "UserManagement", "Delegated authority for Archive operations on UserManagement audit logs", "UserManagement.Archive" },
                    { new Guid("2470b065-aac5-4100-b19a-6fbbcddc8ce1"), "Workflow", "Temporary permission to Restore operations on Workflow sensitive data", "Workflow.Restore" },
                    { new Guid("24d49659-0716-419d-bbc3-5131caa800b1"), "API", "Temporary permission to Schedule operations on API audit logs", "API.Schedule" },
                    { new Guid("25eab17c-18ad-4235-bf9e-2087d5eeeaf4"), "Security", "Limited scope for Edit operations on Security system resources", "Security.Edit" },
                    { new Guid("27d7fb0f-cef5-42f2-b364-95dd8e90a567"), "SystemConfig", "Administrative control over Revoke operations on SystemConfig API endpoints", "SystemConfig.Revoke" },
                    { new Guid("29d7b556-047e-4e94-93be-f81fb959b5a2"), "Audit", "Compliance-related access to Configure operations on Audit configuration settings", "Audit.Configure" },
                    { new Guid("2c29966a-8435-4d3f-ad2b-4fbbd46ae931"), "Integration", "Administrative control over Delegate operations on Integration integration pipelines", "Integration.Delegate" },
                    { new Guid("2c9c22c0-a62f-4889-99fc-b246a62a9ecf"), "Workflow", "Audit capability for Grant operations on Workflow API endpoints", "Workflow.Grant" },
                    { new Guid("2ca9d773-4203-454b-bcef-27db593280c7"), "Workflow", "Security-restricted Create operations on Workflow system resources", "Workflow.Create" },
                    { new Guid("2d4d06e2-89b4-4529-a282-8e20de9b1163"), "Integration", "Delegated authority for Delete operations on Integration configuration settings", "Integration.Delete" },
                    { new Guid("2d5835a2-a82d-4577-b210-1c628d464cb1"), "UserManagement", "Global access to Restore operations on UserManagement API endpoints", "UserManagement.Restore" },
                    { new Guid("2d99030c-27fa-41af-bc96-bcfca362d3ae"), "RoleManagement", "Security-restricted Execute operations on RoleManagement workflow definitions", "RoleManagement.Execute" },
                    { new Guid("2e0b8e78-c8a8-42a7-959b-05cff7c49826"), "Reporting", "Audit capability for Configure operations on Reporting system resources", "Reporting.Configure" },
                    { new Guid("2f6d036d-ea06-41a8-9f5c-2315d84dd1a6"), "Security", "Administrative control over Execute operations on Security configuration settings", "Security.Execute" },
                    { new Guid("30c87ecb-fc6f-4963-84e7-4a62e5adcf5a"), "RoleManagement", "Audit capability for Delegate operations on RoleManagement integration pipelines", "RoleManagement.Delegate" },
                    { new Guid("3126aee7-5fe3-4267-8e59-7428d2ad3e90"), "Security", "Temporary permission to Import operations on Security API endpoints", "Security.Import" },
                    { new Guid("31c2ef4f-1989-4a96-b237-cbde8ba55485"), "Audit", "Audit capability for Unlock operations on Audit reporting modules", "Audit.Unlock" },
                    { new Guid("3251e45c-8fca-4ad7-bb2e-37e801bd4f8b"), "SystemConfig", "Compliance-related access to Execute operations on SystemConfig system resources", "SystemConfig.Execute" },
                    { new Guid("34010ea4-b4a7-4cbe-9213-f277a61a39a2"), "UserManagement", "Temporary permission to Bypass operations on UserManagement workflow definitions", "UserManagement.Bypass" },
                    { new Guid("347f0a56-b2eb-47a3-a622-0b050caffaa3"), "Security", "Compliance-related access to Schedule operations on Security API endpoints", "Security.Schedule" },
                    { new Guid("35ca9929-9912-4c50-a947-bd77303706b9"), "Audit", "Temporary permission to Grant operations on Audit integration pipelines", "Audit.Grant" },
                    { new Guid("37c2d20a-2713-4a51-a9b0-0630975b7624"), "Reporting", "Approval workflow covering View operations on Reporting audit logs", "Reporting.View" },
                    { new Guid("39ce3d6a-1927-47b3-aee6-92051113330b"), "Integration", "Temporary permission to View operations on Integration API endpoints", "Integration.View" },
                    { new Guid("3a0cb33e-8723-4493-bc13-ea1f5be9ad60"), "Workflow", "Administrative control over Lock operations on Workflow API endpoints", "Workflow.Lock" },
                    { new Guid("3a33432d-4886-4908-ac0b-aec7354c06b6"), "Reporting", "Approval workflow covering Grant operations on Reporting integration pipelines", "Reporting.Grant" },
                    { new Guid("3b3059db-3510-4c80-8dd8-400a29b9e17a"), "DataAccess", "Temporary permission to Configure operations on DataAccess integration pipelines", "DataAccess.Configure" },
                    { new Guid("3b7cc10b-efb4-42b9-ba54-e2b373ae6ea6"), "Integration", "Emergency access to Monitor operations on Integration API endpoints", "Integration.Monitor" },
                    { new Guid("3c73804c-9b51-44e9-bc08-b77fbac3ff0d"), "Security", "Approval workflow covering Revoke operations on Security user profiles", "Security.Revoke" },
                    { new Guid("3cef7bdd-b887-4aa9-b855-921c908a333f"), "RoleManagement", "Limited scope for Delete operations on RoleManagement integration pipelines", "RoleManagement.Delete" },
                    { new Guid("3d544a11-b9e4-49ea-bd9d-6fdbc58ea44a"), "RoleManagement", "Limited scope for Schedule operations on RoleManagement user profiles", "RoleManagement.Schedule" },
                    { new Guid("3e390c37-263d-41a0-ad31-c337b2e5edbe"), "DataAccess", "Security-restricted Unlock operations on DataAccess user profiles", "DataAccess.Unlock" },
                    { new Guid("3e7674e0-c7b7-4368-afe1-da53a869f459"), "Audit", "Delegated authority for Bypass operations on Audit reporting modules", "Audit.Bypass" },
                    { new Guid("3ea4332c-957f-4902-8960-7cac92c25ac3"), "Reporting", "Administrative control over Delete operations on Reporting user profiles", "Reporting.Delete" },
                    { new Guid("407b035a-31bb-4e63-b94e-a759c069e5e1"), "Workflow", "Emergency access to Configure operations on Workflow configuration settings", "Workflow.Configure" },
                    { new Guid("409f293f-bac7-43a3-8416-30f7739491a2"), "Integration", "Approval workflow covering Approve operations on Integration user profiles", "Integration.Approve" },
                    { new Guid("40e2a1e3-7238-4f9c-a236-e13623ab3099"), "SystemConfig", "Delegated authority for Bypass operations on SystemConfig user profiles", "SystemConfig.Bypass" },
                    { new Guid("47900bd0-44f1-4167-8542-81dc28f820eb"), "Audit", "Limited scope for Export operations on Audit system resources", "Audit.Export" },
                    { new Guid("47bd7054-c630-4e1b-a580-725d1a77069a"), "Reporting", "Approval workflow covering Import operations on Reporting user profiles", "Reporting.Import" },
                    { new Guid("4929e663-831b-4058-92d9-00a7cbd53241"), "Integration", "Compliance-related access to Execute operations on Integration security policies", "Integration.Execute" },
                    { new Guid("4b7f1e0c-7210-4719-a84d-447ca9629b35"), "SystemConfig", "Emergency access to Create operations on SystemConfig system resources", "SystemConfig.Create" },
                    { new Guid("4c8d6b08-e95e-405b-b5ce-49f5d805034a"), "Reporting", "Limited scope for Restore operations on Reporting workflow definitions", "Reporting.Restore" },
                    { new Guid("4d2c9387-0207-4b2b-8d70-dcdb060ddfa0"), "Security", "Delegated authority for Bypass operations on Security configuration settings", "Security.Bypass" },
                    { new Guid("4d65025c-7adb-491b-8053-d911eb1c353a"), "Reporting", "Compliance-related access to Export operations on Reporting audit logs", "Reporting.Export" },
                    { new Guid("4dec20e1-8455-4512-862a-982bcaf1a07e"), "Workflow", "Compliance-related access to Export operations on Workflow system resources", "Workflow.Export" },
                    { new Guid("4eb219a5-04ac-4142-85c7-51c3a8461184"), "Integration", "Approval workflow covering Bypass operations on Integration security policies", "Integration.Bypass" },
                    { new Guid("4f9b655c-3ce7-4c6a-a5c5-d45505bbf0f0"), "UserManagement", "Global access to Revoke operations on UserManagement sensitive data", "UserManagement.Revoke" },
                    { new Guid("5002893f-8eef-4034-889c-76b2eeadd690"), "RoleManagement", "Administrative control over Monitor operations on RoleManagement audit logs", "RoleManagement.Monitor" },
                    { new Guid("50a91a80-530b-4c62-a628-c4f5d86ede8f"), "API", "Compliance-related access to Archive operations on API reporting modules", "API.Archive" },
                    { new Guid("510eb298-2d47-46fb-9722-abe098f341bf"), "SystemConfig", "Temporary permission to Import operations on SystemConfig API endpoints", "SystemConfig.Import" },
                    { new Guid("53ca7ec8-bbed-4f51-aeeb-7a2f8e451398"), "Workflow", "Security-restricted Bypass operations on Workflow system resources", "Workflow.Bypass" },
                    { new Guid("564ae470-3bc0-4b7f-a2ed-162f4c7dd395"), "SystemConfig", "Emergency access to Approve operations on SystemConfig system resources", "SystemConfig.Approve" },
                    { new Guid("5cefefcf-e127-4c92-85bb-0de671a1e300"), "UserManagement", "Compliance-related access to Execute operations on UserManagement system resources", "UserManagement.Execute" },
                    { new Guid("5e554e99-77bc-4875-b1c4-18c8c3910d1c"), "RoleManagement", "Audit capability for Import operations on RoleManagement configuration settings", "RoleManagement.Import" },
                    { new Guid("5ee5645b-e65f-45f6-885a-53c43df22606"), "Integration", "Compliance-related access to Unlock operations on Integration API endpoints", "Integration.Unlock" },
                    { new Guid("5f91284d-12c5-4004-bb05-d9daefcf7281"), "SystemConfig", "Global access to Edit operations on SystemConfig API endpoints", "SystemConfig.Edit" },
                    { new Guid("62513fdc-dcdb-462d-955c-948a6c2adc26"), "UserManagement", "Limited scope for Import operations on UserManagement system resources", "UserManagement.Import" },
                    { new Guid("627f238d-e08c-4fe3-895a-ebea821240c1"), "Audit", "Delegated authority for Execute operations on Audit security policies", "Audit.Execute" },
                    { new Guid("639b4636-e7c5-4597-b9b2-aa17d60ba98b"), "Workflow", "Approval workflow covering Delete operations on Workflow sensitive data", "Workflow.Delete" },
                    { new Guid("6540fc85-ade9-4201-8bc4-10861d594b65"), "Reporting", "Emergency access to Archive operations on Reporting configuration settings", "Reporting.Archive" },
                    { new Guid("67b079a8-9c7a-4994-86b5-b7ce96ae2ae5"), "API", "Temporary permission to Configure operations on API security policies", "API.Configure" },
                    { new Guid("699b7769-6226-410f-b676-cdfa3560cd78"), "Workflow", "Security-restricted Edit operations on Workflow security policies", "Workflow.Edit" },
                    { new Guid("6b8dc4ae-588d-4738-afeb-38f17327cb29"), "DataAccess", "Global access to Schedule operations on DataAccess configuration settings", "DataAccess.Schedule" },
                    { new Guid("6d5b4088-5b77-4ffb-b764-cad05b7e140e"), "RoleManagement", "Administrative control over Reject operations on RoleManagement reporting modules", "RoleManagement.Reject" },
                    { new Guid("6d99a15e-35fb-434a-b93c-76dd3c4079b2"), "Security", "Audit capability for Delete operations on Security configuration settings", "Security.Delete" },
                    { new Guid("6f381b62-e013-4e0f-a793-24bbb0964926"), "UserManagement", "Emergency access to Delegate operations on UserManagement reporting modules", "UserManagement.Delegate" },
                    { new Guid("6f5c10fe-c3ca-47b2-bba2-79fc338c2624"), "Audit", "Security-restricted Lock operations on Audit security policies", "Audit.Lock" },
                    { new Guid("6f5fe80b-2f68-4062-a521-1443403c6a93"), "RoleManagement", "Approval workflow covering Approve operations on RoleManagement configuration settings", "RoleManagement.Approve" },
                    { new Guid("70a9d9d9-6cb1-487a-a7f8-de47c8918125"), "Integration", "Compliance-related access to Grant operations on Integration user profiles", "Integration.Grant" },
                    { new Guid("7115dcd0-61c2-4cb2-ab72-3f96e8d71686"), "DataAccess", "Compliance-related access to Grant operations on DataAccess API endpoints", "DataAccess.Grant" },
                    { new Guid("7252137f-3853-4838-a41e-c29f69fdedce"), "RoleManagement", "Security-restricted Restore operations on RoleManagement configuration settings", "RoleManagement.Restore" },
                    { new Guid("73083cd1-9c48-4e24-95cd-6171be18fad6"), "Audit", "Security-restricted Edit operations on Audit audit logs", "Audit.Edit" },
                    { new Guid("74664bf8-c992-4fad-bcd7-7cdc81647d3e"), "UserManagement", "Compliance-related access to Export operations on UserManagement integration pipelines", "UserManagement.Export" },
                    { new Guid("748016b4-a474-417d-abc3-5344a872592f"), "Security", "Audit capability for Unlock operations on Security configuration settings", "Security.Unlock" },
                    { new Guid("756caefd-9ab5-43c6-80e6-b1b680bf3fe5"), "API", "Global access to Unlock operations on API sensitive data", "API.Unlock" },
                    { new Guid("7574b4ec-a344-4c14-8304-9f2a5722d8b1"), "API", "Emergency access to Bypass operations on API workflow definitions", "API.Bypass" },
                    { new Guid("75e2bf09-b39c-4445-b46f-21953b9e2f05"), "DataAccess", "Delegated authority for Monitor operations on DataAccess audit logs", "DataAccess.Monitor" },
                    { new Guid("76298891-74bf-4da8-b0fb-4dc094afc0c9"), "SystemConfig", "Audit capability for Export operations on SystemConfig integration pipelines", "SystemConfig.Export" },
                    { new Guid("7917af91-0abf-49cb-bf78-80ec609a4d30"), "SystemConfig", "Delegated authority for Unlock operations on SystemConfig workflow definitions", "SystemConfig.Unlock" },
                    { new Guid("7a943dfb-929c-45be-b793-6029492d6871"), "DataAccess", "Emergency access to Delegate operations on DataAccess sensitive data", "DataAccess.Delegate" },
                    { new Guid("7ae311fa-0899-4c45-a7c2-0a86520b631f"), "API", "Delegated authority for Delegate operations on API reporting modules", "API.Delegate" },
                    { new Guid("7d768196-701b-4f98-b2b7-09b6c4d032c3"), "API", "Security-restricted Delete operations on API API endpoints", "API.Delete" },
                    { new Guid("7eeb765b-349c-4bde-bd17-0669903e365a"), "Security", "Administrative control over Export operations on Security sensitive data", "Security.Export" },
                    { new Guid("7f0cebc3-c82f-45f2-b348-00af42bb6b5d"), "Reporting", "Audit capability for Delegate operations on Reporting API endpoints", "Reporting.Delegate" },
                    { new Guid("8519edb5-2511-4896-947c-6e9248dad40e"), "Reporting", "Audit capability for Approve operations on Reporting configuration settings", "Reporting.Approve" },
                    { new Guid("8726ef8a-22d4-40e3-960c-dfd2f16a9a6c"), "Workflow", "Audit capability for Archive operations on Workflow configuration settings", "Workflow.Archive" },
                    { new Guid("8750bd52-577f-4600-ac90-329b962ee4d5"), "SystemConfig", "Delegated authority for Grant operations on SystemConfig system resources", "SystemConfig.Grant" },
                    { new Guid("87531e04-e5dd-42cb-8b3d-5cfe488fafc1"), "Security", "Audit capability for Delegate operations on Security integration pipelines", "Security.Delegate" },
                    { new Guid("89577654-1e6e-4ca7-a6c9-d6f101b5bd6a"), "Integration", "Delegated authority for Edit operations on Integration security policies", "Integration.Edit" },
                    { new Guid("8a0c643e-4391-47f8-986a-496858ba4f2e"), "DataAccess", "Limited scope for Restore operations on DataAccess audit logs", "DataAccess.Restore" },
                    { new Guid("8e5085b5-dfd3-4b13-98be-7073229a87fb"), "UserManagement", "Global access to Lock operations on UserManagement security policies", "UserManagement.Lock" },
                    { new Guid("8ee7b0f8-8065-4cdc-87ce-592797d8ce18"), "Security", "Limited scope for Lock operations on Security reporting modules", "Security.Lock" },
                    { new Guid("8f0f2d2b-8232-4805-b437-b892a1c21b87"), "API", "Delegated authority for Export operations on API configuration settings", "API.Export" },
                    { new Guid("92533291-0563-4627-b8e8-cdab7055433b"), "DataAccess", "Compliance-related access to Revoke operations on DataAccess sensitive data", "DataAccess.Revoke" },
                    { new Guid("9284d316-a67f-4493-b742-8f40ce2ac2bb"), "RoleManagement", "Compliance-related access to Bypass operations on RoleManagement reporting modules", "RoleManagement.Bypass" },
                    { new Guid("93febb76-5b12-4d44-a0bb-c8ffda461aae"), "UserManagement", "Temporary permission to Create operations on UserManagement configuration settings", "UserManagement.Create" },
                    { new Guid("94cd965c-d28e-40c9-8686-2f11b5c00343"), "SystemConfig", "Compliance-related access to Lock operations on SystemConfig system resources", "SystemConfig.Lock" },
                    { new Guid("9828059a-1d28-4b75-b971-9329297c9632"), "DataAccess", "Emergency access to Create operations on DataAccess API endpoints", "DataAccess.Create" },
                    { new Guid("983dadc9-7cb7-42cd-b291-75d84bec2d56"), "DataAccess", "Audit capability for Reject operations on DataAccess reporting modules", "DataAccess.Reject" },
                    { new Guid("98f6e267-6d16-43dc-a2dc-bbe14f954f1e"), "SystemConfig", "Audit capability for Delete operations on SystemConfig security policies", "SystemConfig.Delete" },
                    { new Guid("993a3b78-b5a7-4e0c-aee4-1441d3d9192a"), "SystemConfig", "Administrative control over Monitor operations on SystemConfig integration pipelines", "SystemConfig.Monitor" },
                    { new Guid("993d8062-6118-4edf-9315-e9ca2f65b3be"), "UserManagement", "Audit capability for Approve operations on UserManagement API endpoints", "UserManagement.Approve" },
                    { new Guid("999b1e1f-502d-4866-bfd8-2c167185558d"), "UserManagement", "Administrative control over View operations on UserManagement user profiles", "UserManagement.View" },
                    { new Guid("99a9fbe2-6942-4270-9a92-cec50cd453ab"), "API", "Global access to Restore operations on API audit logs", "API.Restore" },
                    { new Guid("99fb2476-16ec-4443-91e4-1637dbf8c9fb"), "UserManagement", "Emergency access to Unlock operations on UserManagement user profiles", "UserManagement.Unlock" },
                    { new Guid("9a8c40c0-5c86-4f36-bf62-76a87e5bed91"), "DataAccess", "Emergency access to Import operations on DataAccess integration pipelines", "DataAccess.Import" },
                    { new Guid("9a9a7fbb-2e8d-4691-b7f8-ee584be7b4e2"), "Workflow", "Audit capability for Reject operations on Workflow integration pipelines", "Workflow.Reject" },
                    { new Guid("9b793dd6-7618-4c1a-ba2a-4109cef629c9"), "Integration", "Delegated authority for Archive operations on Integration integration pipelines", "Integration.Archive" },
                    { new Guid("9c404f19-74e0-45e0-aa75-9dcb3e3bffb3"), "RoleManagement", "Limited scope for Export operations on RoleManagement security policies", "RoleManagement.Export" },
                    { new Guid("a1526f4b-7913-4beb-8d81-b3eac2828aa0"), "API", "Audit capability for Lock operations on API workflow definitions", "API.Lock" },
                    { new Guid("a449c910-5dff-407e-87e9-ad2760197c22"), "UserManagement", "Compliance-related access to Schedule operations on UserManagement workflow definitions", "UserManagement.Schedule" },
                    { new Guid("a44bcabb-dbf3-486c-b88c-c90a535c7199"), "DataAccess", "Delegated authority for Export operations on DataAccess sensitive data", "DataAccess.Export" },
                    { new Guid("a4deeb5a-4400-4add-9a63-c0f968b5db3d"), "Reporting", "Temporary permission to Create operations on Reporting workflow definitions", "Reporting.Create" },
                    { new Guid("a54d7c51-2780-4c69-a192-9723930daa9f"), "UserManagement", "Limited scope for Edit operations on UserManagement reporting modules", "UserManagement.Edit" },
                    { new Guid("ad7e1621-151d-47f3-b456-da87fab0f4cd"), "API", "Security-restricted Import operations on API configuration settings", "API.Import" },
                    { new Guid("ae6b4016-a09f-435a-84ca-b36319764e35"), "Security", "Global access to Restore operations on Security user profiles", "Security.Restore" },
                    { new Guid("af4def4f-05a3-4afb-b8ee-cafe01b64ac5"), "Workflow", "Delegated authority for Import operations on Workflow API endpoints", "Workflow.Import" },
                    { new Guid("afbaad3d-2372-43a6-a12f-e204acfe39ed"), "Integration", "Delegated authority for Configure operations on Integration reporting modules", "Integration.Configure" },
                    { new Guid("b1d57247-2060-4a47-b96e-04cd12797342"), "UserManagement", "Audit capability for Delete operations on UserManagement user profiles", "UserManagement.Delete" },
                    { new Guid("b2dfbf2c-e2f0-4bf1-ab0c-4663bd43f04d"), "API", "Emergency access to Create operations on API reporting modules", "API.Create" },
                    { new Guid("b3a62d75-2f7f-4375-bfed-e247624a20ca"), "Audit", "Compliance-related access to Monitor operations on Audit workflow definitions", "Audit.Monitor" },
                    { new Guid("b44b4e54-c7e4-4114-8e6e-69b52054e7fd"), "DataAccess", "Audit capability for View operations on DataAccess security policies", "DataAccess.View" },
                    { new Guid("b4e6cba9-3906-4deb-885b-310ae3422246"), "SystemConfig", "Administrative control over Delegate operations on SystemConfig workflow definitions", "SystemConfig.Delegate" },
                    { new Guid("b67f4d57-9e77-4e2f-9404-ebe5b9c5e8f5"), "DataAccess", "Delegated authority for Approve operations on DataAccess API endpoints", "DataAccess.Approve" },
                    { new Guid("b6ab0601-2f98-45f6-a038-b36eafb9c47d"), "DataAccess", "Emergency access to Lock operations on DataAccess reporting modules", "DataAccess.Lock" },
                    { new Guid("b78da9cd-f66c-472b-b7a0-125951415609"), "Integration", "Security-restricted Revoke operations on Integration workflow definitions", "Integration.Revoke" },
                    { new Guid("b81ff648-0583-4488-bda4-11d6f1f6b692"), "Audit", "Temporary permission to Restore operations on Audit sensitive data", "Audit.Restore" },
                    { new Guid("b9f4b711-f933-4fa0-a5cb-4b0c68718117"), "DataAccess", "Audit capability for Bypass operations on DataAccess configuration settings", "DataAccess.Bypass" },
                    { new Guid("bac52c29-09a1-4ade-aad1-88ba8237929a"), "API", "Emergency access to Revoke operations on API configuration settings", "API.Revoke" },
                    { new Guid("c03b840d-7755-42cf-80b2-b5aefe37b629"), "Security", "Audit capability for Archive operations on Security audit logs", "Security.Archive" },
                    { new Guid("c37f3bf2-bac3-4c13-b255-b368c08d9b08"), "Integration", "Delegated authority for Lock operations on Integration sensitive data", "Integration.Lock" },
                    { new Guid("c7da43ad-d651-46e6-8077-72eb03d6b273"), "Security", "Audit capability for Monitor operations on Security reporting modules", "Security.Monitor" },
                    { new Guid("cfaf14ee-b488-4ff4-8646-4fdfd4b63214"), "Security", "Approval workflow covering Grant operations on Security reporting modules", "Security.Grant" },
                    { new Guid("d04ecf24-7c01-4ed3-80f4-6f3e74001202"), "Integration", "Administrative control over Export operations on Integration configuration settings", "Integration.Export" },
                    { new Guid("d11d4874-d312-4b4f-aaa2-1097e06e0504"), "Workflow", "Temporary permission to Schedule operations on Workflow API endpoints", "Workflow.Schedule" },
                    { new Guid("d16c0bf6-56b6-46e0-822c-d4475bffc83b"), "Security", "Delegated authority for View operations on Security system resources", "Security.View" },
                    { new Guid("d3636e24-e31a-44a8-a9b4-6afdc7965518"), "API", "Emergency access to View operations on API user profiles", "API.View" },
                    { new Guid("d63c4d58-bbb2-4a7a-b1b2-6010ce1f0c26"), "UserManagement", "Administrative control over Monitor operations on UserManagement integration pipelines", "UserManagement.Monitor" },
                    { new Guid("dba0b7e0-8381-49de-9035-95e83cd487c8"), "RoleManagement", "Delegated authority for Configure operations on RoleManagement reporting modules", "RoleManagement.Configure" },
                    { new Guid("dd8172c6-cf10-426d-b85a-cc60a2a3164a"), "API", "Compliance-related access to Execute operations on API security policies", "API.Execute" },
                    { new Guid("dddc8c3c-c753-40df-a306-75c2f5c871e2"), "RoleManagement", "Limited scope for Unlock operations on RoleManagement user profiles", "RoleManagement.Unlock" },
                    { new Guid("def400af-466c-491a-9fd1-3411211dabb1"), "Security", "Emergency access to Configure operations on Security reporting modules", "Security.Configure" },
                    { new Guid("df0b4f31-c682-4459-affb-0fc2e07145fb"), "SystemConfig", "Approval workflow covering Archive operations on SystemConfig configuration settings", "SystemConfig.Archive" },
                    { new Guid("dfaefdd1-4243-4bd0-82d3-92ee12071bd3"), "SystemConfig", "Approval workflow covering Configure operations on SystemConfig security policies", "SystemConfig.Configure" },
                    { new Guid("e0f684c6-8c1d-462e-9eac-945c9eb927aa"), "Audit", "Security-restricted Import operations on Audit workflow definitions", "Audit.Import" },
                    { new Guid("e22dc2fa-b8a8-48e3-b160-cbf3c7c1bcb5"), "Audit", "Limited scope for Schedule operations on Audit integration pipelines", "Audit.Schedule" },
                    { new Guid("e62e4f0e-e6c4-4bd1-8909-3e2b9840ac85"), "Reporting", "Administrative control over Edit operations on Reporting workflow definitions", "Reporting.Edit" },
                    { new Guid("e7b276d3-ccd4-4ed6-ba47-5397469246bd"), "Workflow", "Limited scope for Delegate operations on Workflow audit logs", "Workflow.Delegate" },
                    { new Guid("e8a57c3c-fd34-4af9-98b9-0b1480c87053"), "RoleManagement", "Global access to Lock operations on RoleManagement API endpoints", "RoleManagement.Lock" },
                    { new Guid("e97a3591-b768-445e-b0ba-7caa53220e34"), "Reporting", "Security-restricted Monitor operations on Reporting configuration settings", "Reporting.Monitor" },
                    { new Guid("e99cabea-3566-4540-89c2-9a89fb208fec"), "Workflow", "Security-restricted Revoke operations on Workflow workflow definitions", "Workflow.Revoke" },
                    { new Guid("ea0eded9-18a1-4987-8282-0d1d9980b647"), "Workflow", "Limited scope for Monitor operations on Workflow integration pipelines", "Workflow.Monitor" },
                    { new Guid("ea889b3c-b219-4895-9aa8-b13c3ad111aa"), "Workflow", "Global access to Unlock operations on Workflow workflow definitions", "Workflow.Unlock" },
                    { new Guid("eedfdd19-1205-4e99-9dca-b9cb48434529"), "SystemConfig", "Administrative control over Schedule operations on SystemConfig user profiles", "SystemConfig.Schedule" },
                    { new Guid("f189d1fd-e42d-4acc-9bd5-947b62accf2d"), "DataAccess", "Delegated authority for Delete operations on DataAccess integration pipelines", "DataAccess.Delete" },
                    { new Guid("f329dce1-7b04-46ad-9061-2b8a035e3eef"), "Workflow", "Delegated authority for Approve operations on Workflow configuration settings", "Workflow.Approve" },
                    { new Guid("f7977b71-ec00-4ee9-af8c-87500cba2d23"), "Workflow", "Limited scope for Execute operations on Workflow sensitive data", "Workflow.Execute" },
                    { new Guid("f7ca4a3d-350b-4cca-a7dd-81497b6386b8"), "SystemConfig", "Emergency access to Restore operations on SystemConfig API endpoints", "SystemConfig.Restore" },
                    { new Guid("f823ed4c-3bbe-488e-bfb5-a8f8843dae59"), "UserManagement", "Approval workflow covering Configure operations on UserManagement system resources", "UserManagement.Configure" },
                    { new Guid("fa3a550b-c27f-45d7-9d5c-1b65c8687e24"), "API", "Temporary permission to Approve operations on API audit logs", "API.Approve" },
                    { new Guid("fa6aa3a5-fb4f-4c60-8a8f-d48f221de6ec"), "Audit", "Limited scope for View operations on Audit sensitive data", "Audit.View" },
                    { new Guid("fae30053-6a27-43c6-8872-814555bf8df9"), "Audit", "Approval workflow covering Create operations on Audit workflow definitions", "Audit.Create" },
                    { new Guid("fc3881de-fcec-468b-bb10-4c572f13e52b"), "DataAccess", "Compliance-related access to Archive operations on DataAccess reporting modules", "DataAccess.Archive" },
                    { new Guid("fc4d5c35-570f-417b-8d4d-ae11b038e630"), "Security", "Approval workflow covering Approve operations on Security security policies", "Security.Approve" },
                    { new Guid("fdbb6b0e-57d8-4e47-905a-4b4825b6675b"), "Audit", "Security-restricted Approve operations on Audit audit logs", "Audit.Approve" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("008542dd-0678-42d1-a5b4-296d411fb3cb"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("00926377-e008-44e0-b170-9d413b34a72c"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("00b32205-fd18-4916-925e-1c2dbb3e888b"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("0161cbc9-1821-409e-a4f7-e09a0744905b"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("02385c80-7f3d-4f86-b338-de6e4e14834d"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("02423287-f75a-4bdb-84ce-fbaf5744efd8"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("024a5e59-f9c1-4154-949b-eedb6888d406"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("0767faa4-cb31-4300-b1db-56ffc3c91f8a"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("07e37905-6a91-4f67-bac9-d78286f63d4a"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("089bd578-93ad-4dac-8fe1-6e7b67d7223d"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("08d6cd29-12db-4307-b444-f8c816d10d0b"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("0b4ee39f-d63d-4b64-a105-7cd71b13c9d0"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("0b5573c9-a4bd-427e-9a6d-fdabd2fd95cc"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("0cbd47b8-e0ad-4978-b345-714a21118719"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("0ce6bb6a-c7d2-4072-a344-464ef8ea9120"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("0fc3bdc8-b731-4337-9c8d-fa6ccbe2c02a"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("1006f736-a698-4644-aad4-02668bf75534"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("10517cf6-b644-4e78-8973-b449866fd84a"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("12e26c5b-47b4-4d86-8407-1519c97313dc"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("1345bab8-7d18-451a-844b-1c7d84ba84c9"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("13b0cfc3-73fc-418d-95f3-1c7dd95ad34d"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("14b1c343-d222-4dec-9968-bbc36cf1f0b5"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("1816758c-4cb5-49b5-8d3a-798090dbabb8"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("19b04961-1eb1-4bd0-aa65-992d079cd21e"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("1b6cb8e3-3a48-4502-a0c6-e7b5795dbaf2"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("1c92b10a-7497-412a-9e79-10407e117bff"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("1d5ca28d-3172-472a-a4ce-9c94c20d3b71"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("1dd7b85d-77d3-43ae-b992-a5f635dec756"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("1e9f0884-ff3f-4dc4-b264-4d40722c601d"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("1f51def2-0982-4d0a-9a15-28c9c94126aa"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("20c91abd-9dd0-4712-8f4c-33be0954d7d4"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("20e98afc-b6b0-4c27-b416-ce8de2995c38"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("20face18-4a30-4272-8621-40f21ebadec2"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("2222821d-02d6-4755-bb94-a3781b652090"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("2335fb33-d2e9-48ca-86ac-44c6a550f8b4"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("23411b0c-59a9-44b2-9ab1-fc3e733ba14a"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("23fb4d21-7501-40d8-8501-6e70989ecbda"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("2470b065-aac5-4100-b19a-6fbbcddc8ce1"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("24d49659-0716-419d-bbc3-5131caa800b1"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("25eab17c-18ad-4235-bf9e-2087d5eeeaf4"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("27d7fb0f-cef5-42f2-b364-95dd8e90a567"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("29d7b556-047e-4e94-93be-f81fb959b5a2"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("2c29966a-8435-4d3f-ad2b-4fbbd46ae931"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("2c9c22c0-a62f-4889-99fc-b246a62a9ecf"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("2ca9d773-4203-454b-bcef-27db593280c7"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("2d4d06e2-89b4-4529-a282-8e20de9b1163"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("2d5835a2-a82d-4577-b210-1c628d464cb1"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("2d99030c-27fa-41af-bc96-bcfca362d3ae"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("2e0b8e78-c8a8-42a7-959b-05cff7c49826"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("2f6d036d-ea06-41a8-9f5c-2315d84dd1a6"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("30c87ecb-fc6f-4963-84e7-4a62e5adcf5a"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("3126aee7-5fe3-4267-8e59-7428d2ad3e90"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("31c2ef4f-1989-4a96-b237-cbde8ba55485"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("3251e45c-8fca-4ad7-bb2e-37e801bd4f8b"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("34010ea4-b4a7-4cbe-9213-f277a61a39a2"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("347f0a56-b2eb-47a3-a622-0b050caffaa3"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("35ca9929-9912-4c50-a947-bd77303706b9"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("37c2d20a-2713-4a51-a9b0-0630975b7624"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("39ce3d6a-1927-47b3-aee6-92051113330b"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("3a0cb33e-8723-4493-bc13-ea1f5be9ad60"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("3a33432d-4886-4908-ac0b-aec7354c06b6"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("3b3059db-3510-4c80-8dd8-400a29b9e17a"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("3b7cc10b-efb4-42b9-ba54-e2b373ae6ea6"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("3c73804c-9b51-44e9-bc08-b77fbac3ff0d"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("3cef7bdd-b887-4aa9-b855-921c908a333f"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("3d544a11-b9e4-49ea-bd9d-6fdbc58ea44a"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("3e390c37-263d-41a0-ad31-c337b2e5edbe"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("3e7674e0-c7b7-4368-afe1-da53a869f459"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("3ea4332c-957f-4902-8960-7cac92c25ac3"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("407b035a-31bb-4e63-b94e-a759c069e5e1"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("409f293f-bac7-43a3-8416-30f7739491a2"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("40e2a1e3-7238-4f9c-a236-e13623ab3099"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("47900bd0-44f1-4167-8542-81dc28f820eb"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("47bd7054-c630-4e1b-a580-725d1a77069a"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("4929e663-831b-4058-92d9-00a7cbd53241"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("4b7f1e0c-7210-4719-a84d-447ca9629b35"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("4c8d6b08-e95e-405b-b5ce-49f5d805034a"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("4d2c9387-0207-4b2b-8d70-dcdb060ddfa0"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("4d65025c-7adb-491b-8053-d911eb1c353a"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("4dec20e1-8455-4512-862a-982bcaf1a07e"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("4eb219a5-04ac-4142-85c7-51c3a8461184"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("4f9b655c-3ce7-4c6a-a5c5-d45505bbf0f0"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("5002893f-8eef-4034-889c-76b2eeadd690"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("50a91a80-530b-4c62-a628-c4f5d86ede8f"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("510eb298-2d47-46fb-9722-abe098f341bf"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("53ca7ec8-bbed-4f51-aeeb-7a2f8e451398"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("564ae470-3bc0-4b7f-a2ed-162f4c7dd395"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("5cefefcf-e127-4c92-85bb-0de671a1e300"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("5e554e99-77bc-4875-b1c4-18c8c3910d1c"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("5ee5645b-e65f-45f6-885a-53c43df22606"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("5f91284d-12c5-4004-bb05-d9daefcf7281"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("62513fdc-dcdb-462d-955c-948a6c2adc26"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("627f238d-e08c-4fe3-895a-ebea821240c1"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("639b4636-e7c5-4597-b9b2-aa17d60ba98b"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("6540fc85-ade9-4201-8bc4-10861d594b65"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("67b079a8-9c7a-4994-86b5-b7ce96ae2ae5"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("699b7769-6226-410f-b676-cdfa3560cd78"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("6b8dc4ae-588d-4738-afeb-38f17327cb29"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("6d5b4088-5b77-4ffb-b764-cad05b7e140e"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("6d99a15e-35fb-434a-b93c-76dd3c4079b2"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("6f381b62-e013-4e0f-a793-24bbb0964926"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("6f5c10fe-c3ca-47b2-bba2-79fc338c2624"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("6f5fe80b-2f68-4062-a521-1443403c6a93"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("70a9d9d9-6cb1-487a-a7f8-de47c8918125"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("7115dcd0-61c2-4cb2-ab72-3f96e8d71686"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("7252137f-3853-4838-a41e-c29f69fdedce"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("73083cd1-9c48-4e24-95cd-6171be18fad6"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("74664bf8-c992-4fad-bcd7-7cdc81647d3e"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("748016b4-a474-417d-abc3-5344a872592f"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("756caefd-9ab5-43c6-80e6-b1b680bf3fe5"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("7574b4ec-a344-4c14-8304-9f2a5722d8b1"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("75e2bf09-b39c-4445-b46f-21953b9e2f05"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("76298891-74bf-4da8-b0fb-4dc094afc0c9"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("7917af91-0abf-49cb-bf78-80ec609a4d30"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("7a943dfb-929c-45be-b793-6029492d6871"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("7ae311fa-0899-4c45-a7c2-0a86520b631f"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("7d768196-701b-4f98-b2b7-09b6c4d032c3"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("7eeb765b-349c-4bde-bd17-0669903e365a"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("7f0cebc3-c82f-45f2-b348-00af42bb6b5d"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("8519edb5-2511-4896-947c-6e9248dad40e"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("8726ef8a-22d4-40e3-960c-dfd2f16a9a6c"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("8750bd52-577f-4600-ac90-329b962ee4d5"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("87531e04-e5dd-42cb-8b3d-5cfe488fafc1"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("89577654-1e6e-4ca7-a6c9-d6f101b5bd6a"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("8a0c643e-4391-47f8-986a-496858ba4f2e"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("8e5085b5-dfd3-4b13-98be-7073229a87fb"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("8ee7b0f8-8065-4cdc-87ce-592797d8ce18"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("8f0f2d2b-8232-4805-b437-b892a1c21b87"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("92533291-0563-4627-b8e8-cdab7055433b"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("9284d316-a67f-4493-b742-8f40ce2ac2bb"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("93febb76-5b12-4d44-a0bb-c8ffda461aae"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("94cd965c-d28e-40c9-8686-2f11b5c00343"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("9828059a-1d28-4b75-b971-9329297c9632"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("983dadc9-7cb7-42cd-b291-75d84bec2d56"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("98f6e267-6d16-43dc-a2dc-bbe14f954f1e"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("993a3b78-b5a7-4e0c-aee4-1441d3d9192a"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("993d8062-6118-4edf-9315-e9ca2f65b3be"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("999b1e1f-502d-4866-bfd8-2c167185558d"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("99a9fbe2-6942-4270-9a92-cec50cd453ab"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("99fb2476-16ec-4443-91e4-1637dbf8c9fb"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("9a8c40c0-5c86-4f36-bf62-76a87e5bed91"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("9a9a7fbb-2e8d-4691-b7f8-ee584be7b4e2"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("9b793dd6-7618-4c1a-ba2a-4109cef629c9"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("9c404f19-74e0-45e0-aa75-9dcb3e3bffb3"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("a1526f4b-7913-4beb-8d81-b3eac2828aa0"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("a449c910-5dff-407e-87e9-ad2760197c22"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("a44bcabb-dbf3-486c-b88c-c90a535c7199"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("a4deeb5a-4400-4add-9a63-c0f968b5db3d"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("a54d7c51-2780-4c69-a192-9723930daa9f"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("ad7e1621-151d-47f3-b456-da87fab0f4cd"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("ae6b4016-a09f-435a-84ca-b36319764e35"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("af4def4f-05a3-4afb-b8ee-cafe01b64ac5"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("afbaad3d-2372-43a6-a12f-e204acfe39ed"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("b1d57247-2060-4a47-b96e-04cd12797342"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("b2dfbf2c-e2f0-4bf1-ab0c-4663bd43f04d"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("b3a62d75-2f7f-4375-bfed-e247624a20ca"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("b44b4e54-c7e4-4114-8e6e-69b52054e7fd"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("b4e6cba9-3906-4deb-885b-310ae3422246"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("b67f4d57-9e77-4e2f-9404-ebe5b9c5e8f5"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("b6ab0601-2f98-45f6-a038-b36eafb9c47d"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("b78da9cd-f66c-472b-b7a0-125951415609"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("b81ff648-0583-4488-bda4-11d6f1f6b692"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("b9f4b711-f933-4fa0-a5cb-4b0c68718117"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("bac52c29-09a1-4ade-aad1-88ba8237929a"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("c03b840d-7755-42cf-80b2-b5aefe37b629"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("c37f3bf2-bac3-4c13-b255-b368c08d9b08"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("c7da43ad-d651-46e6-8077-72eb03d6b273"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("cfaf14ee-b488-4ff4-8646-4fdfd4b63214"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("d04ecf24-7c01-4ed3-80f4-6f3e74001202"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("d11d4874-d312-4b4f-aaa2-1097e06e0504"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("d16c0bf6-56b6-46e0-822c-d4475bffc83b"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("d3636e24-e31a-44a8-a9b4-6afdc7965518"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("d63c4d58-bbb2-4a7a-b1b2-6010ce1f0c26"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("dba0b7e0-8381-49de-9035-95e83cd487c8"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("dd8172c6-cf10-426d-b85a-cc60a2a3164a"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("dddc8c3c-c753-40df-a306-75c2f5c871e2"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("def400af-466c-491a-9fd1-3411211dabb1"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("df0b4f31-c682-4459-affb-0fc2e07145fb"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("dfaefdd1-4243-4bd0-82d3-92ee12071bd3"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("e0f684c6-8c1d-462e-9eac-945c9eb927aa"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("e22dc2fa-b8a8-48e3-b160-cbf3c7c1bcb5"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("e62e4f0e-e6c4-4bd1-8909-3e2b9840ac85"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("e7b276d3-ccd4-4ed6-ba47-5397469246bd"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("e8a57c3c-fd34-4af9-98b9-0b1480c87053"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("e97a3591-b768-445e-b0ba-7caa53220e34"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("e99cabea-3566-4540-89c2-9a89fb208fec"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("ea0eded9-18a1-4987-8282-0d1d9980b647"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("ea889b3c-b219-4895-9aa8-b13c3ad111aa"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("eedfdd19-1205-4e99-9dca-b9cb48434529"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("f189d1fd-e42d-4acc-9bd5-947b62accf2d"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("f329dce1-7b04-46ad-9061-2b8a035e3eef"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("f7977b71-ec00-4ee9-af8c-87500cba2d23"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("f7ca4a3d-350b-4cca-a7dd-81497b6386b8"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("f823ed4c-3bbe-488e-bfb5-a8f8843dae59"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("fa3a550b-c27f-45d7-9d5c-1b65c8687e24"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("fa6aa3a5-fb4f-4c60-8a8f-d48f221de6ec"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("fae30053-6a27-43c6-8872-814555bf8df9"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("fc3881de-fcec-468b-bb10-4c572f13e52b"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("fc4d5c35-570f-417b-8d4d-ae11b038e630"));

            migrationBuilder.DeleteData(
                schema: "permissions",
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("fdbb6b0e-57d8-4e47-905a-4b4825b6675b"));
        }
    }
}
