namespace MyPet.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MyPet.Data.Models;

    internal class BreedSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Breeds.Any())
            {
                return;
            }

            var breedDictionary = new Dictionary<string, List<string>>
            {
                { "Cat", new List<string> { "Abyssinian", "Breedless", "British Shorthair", "Burmese", "Cornish Rex", "Devon Rex", "Himalayan", "Maine Coon", "Manx", "Persian", "Russian Blue", "Scottish Fold", "Siamese", "Sphynx", "Turkish Angora", "Turkish Van" } },
                { "Dog", new List<string> { "Affenpinscher", "Afghan hound", "Airedale terrier", "Akita", "Alaskan Malamute", "American Staffordshire terrier", "American water spaniel", "Australian cattle dog", "Australian shepherd", "Australian terrier", "Basenji", "Basset hound", "Beagle", "Bearded collie", "Bedlington terrier", "Bernese mountain dog", "Bichon frise", "Black and tan coonhound", "Bloodhound", "Border collie", "Border terrier", "Borzoi", "Boston terrier", "Bouvier des Flandres", "Boxer", "Breedless", "Briard", "Brittany", "Brussels griffon", "Bull terrier", "Bulldog", "Bullmastiff", "Cairn terrier", "Canaan dog", "Chesapeake Bay retriever", "Chihuahua", "Chinese crested", "Chinese shar-pei", "Chow chow", "Clumber spaniel", "Cocker spaniel", "Collie", "Curly-coated retriever", "Dachshund", "Dalmatian", "Doberman pinscher", "English cocker spaniel", "English setter", "English springer spaniel", "English toy spaniel", "Eskimo dog", "Finnish spitz", "Flat-coated retriever", "Fox terrier", "Foxhound", "French bulldog", "German shepherd", "German shorthaired pointer", "German wirehaired pointer", "Golden retriever", "Gordon setter", "Great Dane", "Greyhound", "Irish setter", "Irish water spaniel", "Irish wolfhound", "Jack Russell terrier", "Japanese spaniel", "Keeshond", "Kerry blue terrier", "Komondor", "Kuvasz", "Labrador retriever", "Lakeland terrier", "Lhasa apso", "Maltese", "Manchester terrier", "Mastiff", "Mexican hairless", "Newfoundland", "Norwegian elkhound", "Norwich terrier", "Otterhound", "Papillon", "Pekingese", "Pointer", "Pomeranian", "Poodle", "Pug", "Puli", "Rhodesian ridgeback", "Rottweiler", "Saint Bernard", "Saluki", "Samoyed", "Schipperke", "Schnauzer", "Scottish deerhound", "Scottish terrier", "Sealyham terrier", "Shetland sheepdog", "Shih tzu", "Siberian husky", "Silky terrier", "Skye terrier", "Staffordshire bull terrier", "Soft-coated wheaten terrier", "Sussex spaniel", "Spitz", "Tibetan terrier", "Vizsla", "Weimaraner", "Welsh terrier", "West Highland white terrier", "Whippet", "Yorkshire terrier" } },
            };

            foreach (var breed in breedDictionary)
            {
                var currSpecie = dbContext.Species.Where(x => x.Name == breed.Key).FirstOrDefault();

                foreach (var breedName in breed.Value)
                {
                    await dbContext.Breeds.AddAsync(new Breed { Name = breedName, Specie = currSpecie });
                }
            }
        }
    }
}
