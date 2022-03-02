using FrameworkCore.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkCore.Model;
using FrameworkCore.Interface.Repository;
using Framework.Repository;

namespace Framework.Service
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IExperienceRepository _experienceRepository;
        private UnitOfWork unitOfWork = new UnitOfWork();
        public ApplicantService()
        {
            /*  _applicantRepository = ObjRepositoryExtension.CreateInstanceApplicantRepository();
              _experienceRepository = ObjRepositoryExtension.CreateInstanceExperienceRepository();*/
        }
        public IEnumerable<Applicant> GetApplicants()
        {
            return unitOfWork.ApplicantRepository.Get();

        }

        public Applicant GetApplicantById(string Id)
        {
            return unitOfWork.ApplicantRepository.GetById(Id);

        }

        public void InsertApplicant(Applicant app)
        {
            unitOfWork.ApplicantRepository.Insert(app);
            unitOfWork.Save();
        
        }

        public void GenerateIdforExperiences(Applicant applicant)
        {
            List<Experience> expCollTobeRemoved = new List<Experience>();
            foreach (var item in applicant.Experiences)
            {
                if (string.IsNullOrEmpty(item.CompanyName))
                {
                    expCollTobeRemoved.Add(item);
                }
            }
            foreach (var itemTobeRemoved in expCollTobeRemoved)
            {
                applicant.Experiences.Remove(itemTobeRemoved);
            }

            int i = 1;
            foreach (var item in applicant.Experiences)
            {
                item.ExperienceId = i.ToString().PadLeft(3, '0');
                i++;
            }
        }

        public void UpdateApplicant(Applicant applicant)
        {
          
          //  var existingApplicant = unitOfWork.ApplicantRepository.GetById(applicant.Id);
        
            var existingApplicant= unitOfWork.ApplicantRepository.Get(x => x.Id == applicant.Id, null, "", true).FirstOrDefault();


            if (existingApplicant != null)
            {
              //  unitOfWork.ApplicantRepository.SetCurrentValue(existingApplicant, applicant);
           
                //update Applicant             
                unitOfWork.ApplicantRepository.Update(applicant, nameof(applicant.TotalExperience));

                //delete Experiences yg diremove
                foreach (var existingExp in existingApplicant.Experiences)
                {
                    if (!applicant.Experiences.Any(x => x.ExperienceId == existingExp.ExperienceId))
                        // _experienceRepository.DeleteExperience(existingExp);
                        unitOfWork.ExperienceRepository.Delete(existingExp);
                }

                //update & insert Experiences
                foreach (var exp in applicant.Experiences)
                {

                  // var existingExp = unitOfWork.ExperienceRepository.GetById(exp.ExperienceId, exp.ApplicantId);
                   var existingExp = unitOfWork.ExperienceRepository.Get(x => x.ApplicantId == exp.ApplicantId && x.ExperienceId == exp.ExperienceId, null, "", true);
                    if (existingExp != null)
                    {
                       // unitOfWork.ExperienceRepository.SetCurrentValue(existingExp, exp);

                        //update 
                        unitOfWork.ExperienceRepository.Update(exp);
                    }
                    else
                    {
                        Experience lastExperienceId = applicant.Experiences.OrderByDescending(x => x.ExperienceId).FirstOrDefault();

                        string newExperienceId = "001";

                        if (lastExperienceId.ExperienceId != null)
                        {
                            int lastNumber = (Convert.ToInt32(lastExperienceId.ExperienceId.TrimStart('0')) + 1);
                            newExperienceId = lastNumber.ToString().PadLeft(3, '0');
                        }

                        //add
                        var newExp = new Experience()
                        {
                            ExperienceId = newExperienceId,
                            ApplicantId = applicant.Id,
                            CompanyName = exp.CompanyName,
                            Designation = exp.Designation,
                            YearsWorked = exp.YearsWorked
                        };

                        unitOfWork.ExperienceRepository.Insert(newExp);
                       // existingApplicant.Experiences.Add(newExp);

                    }
                }

                unitOfWork.Save();
            }
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

    }
}
