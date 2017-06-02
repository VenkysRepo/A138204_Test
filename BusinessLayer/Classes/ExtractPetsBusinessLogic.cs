using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.View_Models;
using DataAccessLayer.Interfaces;
using Models.Domain_Models;
using Common.Constants;

namespace BusinessLayer.Classes
{
    public class ExtractPetsBusinessLogic : IExtractPetsBusinessLogic
    {
        private IGetPetsJson getPetsJson;

        public ExtractPetsBusinessLogic(IGetPetsJson getPetsJson)
        {
            this.getPetsJson = getPetsJson;
        }
        public ListofPets getSortedPetsbyGender()
        {
            var jsondata = getPetsJson.getJsonData();
            ListofPets petsByGender = null;
            try
            {
                if (jsondata != null)
                {

                    petsByGender = CategorizePetsByGender(jsondata);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return petsByGender;
        }

        private ListofPets CategorizePetsByGender(List<PetJson> jsondata)
        {
            ListofPets petsbyGender = new ListofPets();
            try
            {
                var petsGroupedbyGender = jsondata.GroupBy(x => x.gender).ToDictionary(g => g.Key, g => g.ToList());
                var petslistMale = petsGroupedbyGender.Where(p => p.Key == Constants.Male).Select(x => x.Value).FirstOrDefault().Select(x => x.pets).ToList();
                var petslistFeMale = petsGroupedbyGender.Where(p => p.Key == Constants.Female).Select(x => x.Value).FirstOrDefault().Select(x => x.pets).ToList();
                var malePets = this.getlist(petslistMale);
                var femalepets = this.getlist(petslistFeMale);
                petsbyGender.SortedList.Add(new SortedPetsListbyGender { Gender = Constants.Male, petsList = this.FilterPets(malePets, Constants.Cat) });
                petsbyGender.SortedList.Add(new SortedPetsListbyGender { Gender = Constants.Female, petsList = this.FilterPets(femalepets, Constants.Cat) });
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return petsbyGender;
        }

        private List<Pet> getlist(List<List<Pet>> petslist)
        {
            List<Pet> petlist = new List<Pet>();
            try
            {
                if (petslist != null)
                {
                    foreach (var x in petslist)
                    {
                        if (x != null)
                        {
                            foreach (var item in x)
                            {
                                petlist.Add(item);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return petlist;
        }
        private List<string> FilterPets(List<Pet> petslist, string type)
        {
            List<string> pets = new List<string>();
            try
            {
                foreach (var pet in petslist)
                {
                    if (pet.type == type)
                    {
                        pets.Add(pet.name);
                    }
                }

            }
            catch(Exception ex)
            {
                throw ex;
            
            }

            return pets.OrderBy(x => x).ToList();
        }
    }
}
