using AptMgmtPortalAPI.Data;
using AptMgmtPortalAPI.Entity;
using AptMgmtPortalAPI.Types;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace TestAptMgmtPortal
{
    public class TestUtil
    {
        public static DbContextOptions<AptMgmtDbContext> GetMemDbOptions(string dbName)
        {
            var sqlite = new SqliteConnection("Filename=:memory:");
            sqlite.Open();
            var options = new DbContextOptionsBuilder<AptMgmtDbContext>()
                       .UseSqlite(sqlite)
                       .Options;

            using (var db = new AptMgmtDbContext(options))
            {
                db.Database.Migrate();
            }

            return options;
        }

        public static Tenant NewTenant(AptMgmtDbContext context)
        {
            var tenant = new Tenant();
            tenant.FirstName = "testFirstName";
            tenant.Email = "newtestemail@test.com";
            tenant.UserId = TestUtil.NewUser(context).UserId;
            context.Add(tenant);
            context.SaveChanges();
            return tenant;
        }

        public static Unit NewUnit(AptMgmtDbContext context)
        {

            var unit = new Unit();
            unit.UnitNumber = "3111";
            unit.TenantId = TestUtil.NewTenant(context).TenantId;
            context.Add(unit);
            context.SaveChanges();
            return unit;
        }

        public static User NewUserWithAnAPIKey(AptMgmtDbContext context)
        {
            var user = new User
            {
                ApiKey = "test-key100"
            };
            context.Add(user);
            context.SaveChanges();
            return user;
        }

        public static User NewUser(AptMgmtDbContext context)
        {
            var user = new User();
            context.Add(user);
            context.SaveChanges();
            return user;
        }

        public static AptMgmtPortalAPI.DTO.UserDTO NewUserDtoWithCredential(AptMgmtDbContext context)
        {
            var userDto = new AptMgmtPortalAPI.DTO.UserDTO
            {
                FirstName = "original first name",
                LoginName = "testUser",
                Password = "testpassword"
            };
            return userDto;
        }

        public static (AptMgmtPortalAPI.DTO.UserDTO, Tenant) UserInfoAndTenantForUserRepo(AptMgmtDbContext context)
        {
            var userInfo = TestUtil.NewUserDtoWithCredential(context);
            var tenant = new Tenant
            {
                Email = "testUser",
                UserId = userInfo.UserId,
                FirstName = "original first name",
            };
            context.Add(tenant);
            context.SaveChanges();
            return (userInfo, tenant);

        }

        public static Unit NewUnit(AptMgmtDbContext context, string unitNumber)
        {
            var unit = new Unit();
            unit.UnitNumber = unitNumber;

            context.Add(unit);
            context.SaveChanges();

            return unit;
        }

        public static TenantResourceUsage UseResource(AptMgmtDbContext context,
                                                      int tenantId,
                                                      double amount,
                                                      ResourceType resourceType)
        {
            // All test data is 2 years into the future.
            var testPeriod = new TimeSpan(730, 0, 0, 0);
            var consumedResource = new TenantResourceUsage
            {
                SampleTime = DateTime.Now + testPeriod,
                UsageAmount = amount,
                ResourceType = resourceType,
                TenantId = tenantId,
            };

            context.Add(consumedResource);
            context.SaveChanges();

            return consumedResource;
        }

        public static BillingPeriod NewBillingPeriod(AptMgmtDbContext context)
        {
            var period = new BillingPeriod();
            var timeSpan = new TimeSpan(0, 0, 5);

            // All test data is 2 years into the future.
            var testPeriod = new TimeSpan(730, 0, 0, 0);
            period.PeriodStart = DateTime.Now + testPeriod - timeSpan;
            period.PeriodEnd = DateTime.Now + testPeriod + timeSpan;

            context.Add(period);
            context.SaveChanges();

            return period;
        }

        public static Payment NewPayment(AptMgmtDbContext context, int tenantId)
        {
            var payment = new Payment();
            payment.TenantId = tenantId;

            context.Add(payment);
            context.SaveChanges();

            return payment;
        }

        public static ResourceUsageRate NewResourceRate(AptMgmtDbContext context,
                                                double rate,
                                                ResourceType resource,
                                                BillingPeriod period)
        {
            var newRate = new ResourceUsageRate();
            newRate.PeriodStart = period.PeriodStart;
            newRate.PeriodEnd = period.PeriodEnd;
            newRate.Rate = rate;
            newRate.ResourceType = resource;

            context.Add(newRate);
            context.SaveChanges();

            return newRate;
        }

        public static AgreementTemplate NewAgreement(AptMgmtDbContext context, string title)
        {
            var agreement = new AgreementTemplate();
            agreement.Title = title;

            context.Add(agreement);
            context.SaveChanges();

            return agreement;
        }

        public static Agreement SignAgreement(AptMgmtDbContext context, int agreementId, int tenantId)
        {
            // All test data is 2 years into the future.
            var testPeriod = new TimeSpan(730, 0, 0, 0);

            var signedAgreement = new Agreement();
            signedAgreement.TenantId = tenantId;
            signedAgreement.AgreementTemplateId = agreementId;
            signedAgreement.SignedDate = DateTime.Now;
            signedAgreement.StartDate = DateTime.Now + testPeriod - new TimeSpan(0, 0, 5);
            signedAgreement.EndDate = DateTime.Now + testPeriod + new TimeSpan(0, 0, 5);

            context.Add(signedAgreement);
            context.SaveChanges();

            return signedAgreement;
        }
    }
}
