﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyDescriptionLogic : BaseLogic<CompanyDescriptionPoco>
    {
        public CompanyDescriptionLogic(IDataRepository<CompanyDescriptionPoco> repository) : base(repository)
        {
        }
        public override void Add(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);

            base.Add(pocos);
        }

        public override void Update(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyDescriptionPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();


            foreach (var poco in pocos)
            {
                
              if (string.IsNullOrEmpty(poco.CompanyDescription)||poco.CompanyDescription.Length > 2|| poco.CompanyDescription.Length==2)
                {
                    exceptions.Add(new ValidationException(107, $"CompanyDescription for CompanyDescription {poco.Id} must be greater than 2 characters."));
                }
               
               if (String.IsNullOrEmpty(poco.CompanyName)||poco.CompanyName.Length > 2|| poco.CompanyName.Length==2)
                {
                    exceptions.Add(new ValidationException(106, $"CompanyName for CompanyDescription {poco.Id} must be greater than 2 characters."));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
