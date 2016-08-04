using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Web.Configuration;

namespace PortalService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드, svc 및 config 파일에서 클래스 이름 "Portal"을 변경할 수 있습니다.
    // 참고: 이 서비스를 테스트하기 위해 WCF 테스트 클라이언트를 시작하려면 솔루션 탐색기에서 Portal.svc나 Portal.svc.cs를 선택하고 디버깅을 시작하십시오.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Portal : IPortal
    {
   
        public List<CompanyTable> GridPortlet()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var listCompany = db.CompanyTable.ToList();
            
            return listCompany;
        }
        public void AddCompany(CompanyContract company)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            CompanyTable Company = new CompanyTable
            {
                company = company.company,
                change = company.change,
                pctChange = company.pctChange
            };
            db.CompanyTable.InsertOnSubmit(Company);
            db.SubmitChanges();
        }

        public void DeleteCompany(CompanyContract company)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            CompanyTable deleteCompany = db.CompanyTable.Where(e => e.company==company.company).Single(); 
            db.CompanyTable.DeleteOnSubmit(deleteCompany);
            db.SubmitChanges();
        }
        public void UpdateCompany(CompanyContract company)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            CompanyTable Company = db.CompanyTable.Single(p => p.company == company.company);
            Company.company = company.company;
            Company.change = company.change;
            Company.pctChange = company.pctChange;

            db.SubmitChanges();
        }
    }
}
