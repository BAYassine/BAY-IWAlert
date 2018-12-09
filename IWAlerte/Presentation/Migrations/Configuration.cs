namespace Presentation.Migrations
{
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Service;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Presentation.IWContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Presentation.IWContext context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            IServiceDisease ServiceDisease = new ServiceDisease();
            IServiceAlerte ServiceAlerte = new ServiceAlerte();
         
            string name = "Admin";
            string password = "123456";
            if (!RoleManager.RoleExists(name))
            {
                var roleresult = RoleManager.Create(new IdentityRole(name));
                RoleManager.Create(new IdentityRole("Membre"));
                RoleManager.Create(new IdentityRole("Medecin"));
            }
            var user = new ApplicationUser();

            Place place = new Place()
            {
                Country = Pays.Tunisia.ToString(),
                Town = "Tunis"
            };
            user.Place = place;
            user.UserName = name;
            user.Place = new Place
            {
                Country = "Tunisia", Town = "Tunis"
            };
            var adminresult = UserManager.Create(user, password);
            if (adminresult.Succeeded)
            {
                var result = UserManager.AddToRole(user.Id, name);
            }
            
            Disease Chikungunya = new Disease()
            {
                Picture="1.jpeg",
                Name = "Chikungunya",
                Description = "Chikungunya is a mosquito-borne viral disease first described during an outbreak in southern Tanzania in 1952. It is an RNA virus that belongs to the alphavirus genus of the family Togaviridae. The name “chikungunya” derives from a word in the Kimakonde language, meaning “to become contorted”, and describes the stooped appearance of sufferers with joint pain (arthralgia)."
            };
            Disease Crimean_Congo_haemorrhagic_fever = new Disease()
            {
                Picture = "2.jpg",
                Name = "Crimean-Congo haemorrhagic fever",
                Description = "Crimean-Congo haemorrhagic fever is a viral haemorrhagic fever transmitted by ticks. It can be responsible for severe outbreaks in humans but it is not pathogenic for ruminants, their amplifying host. The disease was first described in the Crimea in 1944 and given the name Crimean haemorrhagic fever.In 1969 it was recognized that the pathogen causing Crimean haemorrhagic fever was the same as that responsible for an illness identified in 1956 in the Congo, and linkage of the two place names resulted in the current name for the disease and the virus."
            };
            Disease Cholera = new Disease()
            {
                Picture = "3.jpg",
                Name = "Cholera",
                Description = "Cholera is an infectious disease that causes severe watery diarrhea, which can lead to dehydration and even death if untreated. It is caused by eating food or drinking water contaminated with a bacterium called Vibrio cholerae. The disease is most common in places with poor sanitation, crowding, war, and famine. Common locations include parts of Africa, south Asia, and Latin America. If you are traveling to one of those areas, knowing the following cholera facts can help protect you and your family."
            };
            Disease Ebola_virus_disease = new Disease()
            {
                Picture = "4.jpg",
                Name = "Ebola virus disease",
                Description = "The Ebola virus causes an acute, serious illness which is often fatal if untreated. Ebola virus disease (EVD) first appeared in 1976 in 2 simultaneous outbreaks, one in what is now, Nzara, South Sudan, and the other in Yambuku, Democratic Republic of Congo. The latter occurred in a village near the Ebola River, from which the disease takes its name. The 2014–2016 outbreak in West Africa was the largest and most complex Ebola outbreak since the virus was first discovered in 1976. There were more cases and deaths in this outbreak than all others combined. It also spread between countries, starting in Guinea then moving across land borders to Sierra Leone and Liberia."
            };
            Disease Hendra_virus_infection = new Disease()
            {
                Picture = "5.jpg",
                Name = "Hendra virus infection",
                Description = "Hendra virus infection is a serious condition which can be fatal caused by Hendra virus. The virus was first discovered after an outbreak of illness in horses at a stable in Hendra, Brisbane in 1994. Since then, seven people have been confirmed to have Hendra virus infection, four of whom died."
            };
            Disease Influenza = new Disease()
            {
                Picture = "6.jpg",
                Name  = "Influenza",
                Description = "commonly known as the flu, is an infectious disease caused by an influenza virus. Symptoms can be mild to severe. The most common symptoms include: high fever, runny nose, sore throat, muscle pains, headache, coughing, sneezing, and feeling tired.s"
            };
            Disease Lassa_fever = new Disease()
            {
                Picture = "7.jpg",
                Name = "Lassa fever",
                Description = "Lassa fever, also known as Lassa hemorrhagic fever (LHF), is a type of viral hemorrhagic fever caused by the Lassa virus. Many of those infected by the virus do not develop symptoms. When symptoms occur they typically include fever, weakness, headaches, vomiting, and muscle pains. Less commonly there may be bleeding from the mouth or gastrointestinal tract. The risk of death once infected is about one percent and frequently occurs within two weeks of the onset of symptoms. Among those who survive about a quarter have hearing loss, which improves over time in about half."
            };
            Symptom SymptomOfChikungunya = new Symptom()
            {
                Description = "High fever ,Severe muscle and joint pain ,Severe headache , Nausea ,Vomiting ,Rash on the skin due to damaged blood vessels ,Enlarged painful lymph node in the neck ,Sore throat ,Painful abdominal cramps, Cold fingers and toes , Dizziness ,Constipation",
                Picture = "1.jpeg"
            };
            Symptom SymptomOfCholera = new Symptom()
            {
                Description = "Diarrhea. Cholera-related diarrhea comes on suddenly and may quickly cause dangerous fluid loss — as much as a quart (about 1 liter) an hour. Diarrhea due to cholera often has a pale, milky appearance that resembles water in which rice has been rinsed (rice-water stool). Nausea and vomiting. Occurring especially in the early stages of cholera, vomiting may persist for hours at a time. Dehydration. Dehydration can develop within hours after the onset of cholera symptoms. Depending on how many body fluids have been lost, dehydration can range from mild to severe. A loss of 10 percent or more of total body weight indicates severe dehydration.",
                Picture = "2.jpg"
            };
            Symptom SymptomOfCrimean_Congo_haemorrhagic_fever = new Symptom()
            {
                Description= "The length of the incubation period depends on the mode of acquisition of the virus. Following infection by a tick bite, the incubation period is usually one to three days, with a maximum of nine days. The incubation period following contact with infected blood or tissues is usually five to six days, with a documented maximum of 13 days. Onset of symptoms is sudden, with fever, myalgia, (muscle ache), dizziness, neck pain and stiffness, backache, headache, sore eyes and photophobia (sensitivity to light). There may be nausea, vomiting, diarrhoea, abdominal pain and sore throat early on, followed by sharp mood swings and confusion. After two to four days, the agitation may be replaced by sleepiness, depression and lassitude, and the abdominal pain may localize to the upper right quadrant, with detectable hepatomegaly (liver enlargement). Other clinical signs include tachycardia (fast heart rate), lymphadenopathy (enlarged lymph nodes), and a petechial rash (a rash caused by bleeding into the skin) on internal mucosal surfaces, such as in the mouth and throat, and on the skin. The petechiae may give way to larger rashes called ecchymoses, and other haemorrhagic phenomena. There is usually evidence of hepatitis, and severely ill patients may experience rapid kidney deterioration, sudden liver failure or pulmonary failure after the fifth day of illness.",
                Picture ="3.jpg"
            };
            Symptom SymptomOfEbola = new Symptom()
            {
                Description= "High fever , Headache , Joint and muscle aches , Sore throat ,Weakness ,Stomach pain , Lack of appetite",
                Picture = "4.jpg"
            };
            Treatement TreatementOfChikungunya = new Treatement()
            {
                Description = "Several methods can be used for diagnosis. Serological tests, such as enzyme-linked immunosorbent assays (ELISA), may confirm the presence of IgM and IgG anti-chikungunya antibodies. IgM antibody levels are highest 3 to 5 weeks after the onset of illness and persist for about 2 months. Samples collected during the first week after the onset of symptoms should be tested by both serological and virological methods (RT-PCR). The virus may be isolated from the blood during the first few days of infection. Various reverse transcriptase–polymerase chain reaction (RT–PCR) methods are available but are of variable sensitivity. Some are suited to clinical diagnosis. RT–PCR products from clinical samples may also be used for genotyping of the virus, allowing comparisons with virus samples from various geographical sources."
            };
            Treatement TreatementOfCholera = new Treatement()
            {
                Description = "Most persons infected with the cholera bacterium have mild diarrhea or no symptoms at all. Only a small proportion, about 5-10%, of persons infected with Vibrio cholerae O1 may have illness requiring treatment at a health center. Cholera patients should be evaluated and treated quickly. With proper treatment, even severely ill patients can be saved."
            };
            Treatement TreatementOfCrimean_Congo_haemorrhagic_fever = new Treatement()
            {
                Description = "Crimean–Congo hemorrhagic fever (CCHF) caused by the CCHF virus, a member of the family Bunyaviridae, genus Nairovirus, is a tick-borne acute viral hemorrhagic fever with a high case–fatality rate. Ribavirin has been used as a treatment for patients with CCHF. Although the efficacy of ribavirin in the treatment of CCHF has not yet been proven conclusively, its use in the early stage of the disease is recommended. A number of clinical and virological insights into CCHF have been revealed. Virus-associated hemophagocytic syndrome has been found to contribute to the exacerbation of CCHF in some patients, and the administration of methylprednisolone at high doses was observationally undertaken in patients with CCHF and virus-associated hemophagocytic syndrome, with promising results. It is expected that effective therapeutics and preventive measures will be developed in the future."
            };
            Cholera.Treatements.Add(TreatementOfCholera);
            Chikungunya.Treatements.Add(TreatementOfChikungunya);
            Crimean_Congo_haemorrhagic_fever.Treatements.Add(TreatementOfCrimean_Congo_haemorrhagic_fever);
            Chikungunya.Symptoms.Add(SymptomOfChikungunya);
            Cholera.Symptoms.Add(SymptomOfCholera) ;
            Crimean_Congo_haemorrhagic_fever.Symptoms.Add(SymptomOfCrimean_Congo_haemorrhagic_fever);
            Ebola_virus_disease.Symptoms.Add(SymptomOfEbola);
            ServiceDisease.Add(Chikungunya);
            ServiceDisease.Add(Crimean_Congo_haemorrhagic_fever);
            ServiceDisease.Add(Cholera);
            ServiceDisease.Add(Ebola_virus_disease);
            ServiceDisease.Add(Hendra_virus_infection);
            ServiceDisease.Add(Influenza);
            ServiceDisease.Add(Lassa_fever);
            ServiceDisease.Commit();
            
            base.Seed(context);
        }
    }
}
