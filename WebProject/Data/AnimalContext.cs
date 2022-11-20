using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using WebProject.Models;

namespace WebProject.Data
{
    public class AnimalContext : DbContext
    {
        public AnimalContext(DbContextOptions<AnimalContext> options) : base(options) { }


        public DbSet<Animal>? Animals { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Comment>? Comments { get; set; }

        protected override async void OnModelCreating(ModelBuilder model)
        {

            model.Entity<Category>().HasData(

                new { CategoryId = 1, Name = "Mammal" },
                new { CategoryId = 2, Name = "Bird" },
                new { CategoryId = 3, Name = "Fish" },
                new { CategoryId = 4, Name = "Reptile" },
                new { CategoryId = 5, Name = "Amphibians" },
                new { CategoryId = 6, Name = "Invertebrates" }
                );

            int id = 0;
            model.Entity<Animal>().HasData(
               new { AnimalId = ++id, Name = "Dog", Age = 5, CategoryId = 1, PictureName = "Assets\\Dog.jfif", Description = "The dog  is a domesticated descendant of the wolf. Also called the domestic dog, it is derived from the extinct Pleistocene wolf, and the modern wolf is the dog's nearest living relative. The dog was the first species to be domesticated, by hunter-gatherers over 15,000 years ago, before the development of agriculture. Due to their long association with humans, dogs have expanded to a large number of domestic individuals and gained the ability to thrive on a starch-rich diet that would be inadequate for other canids." },
               new { AnimalId = ++id, Name = "Cat", Age = 2, CategoryId = 1, PictureName = "Assets\\cat.jfif", Description = "The cat is a domestic species of small carnivorous mammal. It is the only domesticated species in the family Felidae and is commonly referred to as the domestic cat or house cat to distinguish it from the wild members of the family. A cat can either be a house cat, a farm cat, or a feral cat; the feral cat ranges freely and avoids human contact. Domestic cats are valued by humans for companionship and their ability to kill rodents. About 60 cat breeds are recognized by various cat registries." },
               new { AnimalId = ++id, Name = "Proboscis Monkey", Age = 5, CategoryId = 1, PictureName = "Assets\\ProboscisMonkey.jfif", Description = "The proboscis monkey (Nasalis larvatus) or long-nosed monkey is an arboreal Old World monkey with an unusually large nose, a reddish-brown skin color and a long tail. It is endemic to the southeast Asian island of Borneo and is found mostly in mangrove forests and on the coastal areas of the island." },
               new { AnimalId = ++id, Name = "Dolphin", Age = 12, CategoryId = 1, PictureName = "Assets\\Dolphin.jfif", Description = "Dolphins range in size from the 1.7-metre-long (5 ft 7 in) and 50-kilogram (110-pound) Maui's dolphin to the 9.5 m (31 ft 2 in) and 10-tonne (11-short-ton) orca. Various species of dolphins exhibit sexual dimorphism where the males are larger than females. They have streamlined bodies and two limbs that are modified into flippers." },
               new { AnimalId = ++id, Name = "Bat", Age = 3, CategoryId = 1, PictureName = "Assets\\Bat.jpg", Description = "The second largest order of mammals after rodents, bats comprise about 20% of all classified mammal species worldwide, with over 1,400 species. These were traditionally divided into two suborders: the largely fruit-eating megabats, and the echolocating microbats. But more recent evidence has supported dividing the order into Yinpterochiroptera and Yangochiroptera, with megabats as members of the former along with several species of microbats." },


               new { AnimalId = ++id, Name = "grey parrot", Age = 3, CategoryId = 2, PictureName = "Assets\\GreyParrot.jpg", Description = "The grey parrot (Psittacus erithacus), also known as the Congo grey parrot, Congo African grey parrot or African grey parrot, is an Old World parrot in the family Psittacidae. The Timneh parrot (Psittacus timneh) once was identified as a subspecies of the grey parrot, but has since been elevated to a full species." },
               new { AnimalId = ++id, Name = "Eagle", Age = 12, CategoryId = 2, PictureName = "Assets\\Eagle.jfif", Description = "Eagle is the common name for many large birds of prey of the family Accipitridae. Eagles belong to several groups of genera, some of which are closely related. Most of the 60 species of eagle are from Eurasia and Africa. Outside this area, just 14 species can be found—2 in North America, 9 in Central and South America, and 3 in Australia." },
               new { AnimalId = ++id, Name = "Corvus", Age = 4, CategoryId = 2, PictureName = "Assets\\Corvus.jpg", Description = "Corvus is a widely distributed genus of medium-sized to large birds in the family Corvidae. It includes species commonly known as crows, ravens and rooks. The species commonly encountered in Europe are the carrion crow, the hooded crow, the common raven and the rook; those discovered later were named \"crow\" or \"raven\" chiefly on the basis of their size, crows generally being smaller. The genus name is Latin for \"crow\"." },
               new { AnimalId = ++id, Name = "Ciconia", Age = 15, CategoryId = 2, PictureName = "Assets\\Ciconia.jpg", Description = "Ciconia is a genus of birds in the stork family. Six of the seven living species occur in the Old World, but the maguari stork has a South American range. In addition, fossils suggest that Ciconia storks were somewhat more common in the tropical Americas in prehistoric times." },


               new { AnimalId = ++id, Name = "Salmon", Age = 2, CategoryId = 3, PictureName = "Assets\\Salmon.jfif", Description = "The Atlantic salmon (Salmo salar) is a species of ray-finned fish in the family Salmonidae. It is the third largest of the Salmonidae, behind Siberian taimen and Pacific Chinook salmon, growing up to a meter in length. Atlantic salmon are found in the northern Atlantic Ocean and in rivers that flow into it. Most populations are anadromous, hatching in streams and rivers but moving out to sea as they grow where they mature, after which the adults seasonally move upstream again to spawn." },
               new { AnimalId = ++id, Name = "Tetraodontidae", Age = 1, CategoryId = 3, PictureName = "Assets\\Tetraodontidae.jfif", Description = "Tetraodontidae is a family of primarily marine and estuarine fish of the order Tetraodontiformes. The family includes many familiar species variously called pufferfish, puffers, balloonfish, blowfish, blowies, bubblefish, globefish, swellfish, toadfish, toadies, toadle, honey toads, sugar toads, and sea squab." },
               new { AnimalId = ++id, Name = "Hippocampus", Age = 1, CategoryId = 3, PictureName = "Assets\\Hippocampus.jpg", Description = "A seahorse (also written sea-horse and sea horse) is any of 46 species of small marine fish in the genus Hippocampus. \"Hippocampus\" comes from the Ancient Greek hippókampos (ἱππόκαμπος), itself from híppos (ἵππος) meaning \"horse\" and kámpos (κάμπος) meaning \"sea monster\" or \"sea animal\"" },
               new { AnimalId = ++id, Name = "Dasyatidae", Age = 3, CategoryId = 3, PictureName = "Assets\\Dasyatidae.jpg", Description = "The whiptail stingrays are a family, the Dasyatidae, of rays in the order Myliobatiformes. They are found worldwide in tropical to temperate marine waters, and a number of species have also penetrated into fresh water in Africa, Asia, and Australia. Members of this family have flattened pectoral fin discs that range from oval to diamond-like in shape. " },


               new { AnimalId = ++id, Name = "Python Snake", Age = 11, CategoryId = 4, PictureName = "Assets\\PythonSnake.jfif", Description = "The Pythonidae, commonly known as pythons, are a family of nonvenomous snakes found in Africa, Asia, and Australia. Among its members are some of the largest snakes in the world. Ten genera and 42 species are currently recognized." },
               new { AnimalId = ++id, Name = "Draco Volans", Age = 5, CategoryId = 4, PictureName = "Assets\\DracoVolans.jfif", Description = "Draco volans, also commonly known as the common flying dragon, is a species of lizard in the family Agamidae. The species is endemic to Southeast Asia." },
               new { AnimalId = ++id, Name = "Alligator", Age = 22, CategoryId = 4, PictureName = "Assets\\Alligator.jfif", Description = "An alligator is a large reptile in the Crocodilia order in the genus Alligator of the family Alligatoridae. The two extant species are the American alligator (A. mississippiensis) and the Chinese alligator (A. sinensis). Additionally, several extinct species of alligator are known from fossil remains. Alligators first appeared during the Oligocene epoch about 37 million years ago.[" },
               new { AnimalId = ++id, Name = "Turtle", Age = 45, CategoryId = 4, PictureName = "Assets\\Turtle.jfif", Description = "Turtles are an order of reptiles known as Testudines, characterized by a shell developed mainly from their ribs. Modern turtles are divided into two major groups, the Pleurodira (side necked turtles) and Cryptodira (hidden necked turtles), which differ in the way the head retracts. " },


               new { AnimalId = ++id, Name = "Medusozoa ", Age = 20, CategoryId = 6, PictureName = "Assets\\Medusozoa.jpg", Description = "Medusozoa is a clade in the phylum Cnidaria, and is often considered a subphylum. It includes the classes Hydrozoa, Scyphozoa, Staurozoa and Cubozoa, and possibly the parasitic Polypodiozoa. Medusozoans are distinguished by having a medusa stage in their often complex life cycle, a medusa typically being an umbrella-shaped body with stinging tentacles around the edge." },
               new { AnimalId = ++id, Name = "Crustacea", Age = 4, CategoryId = 6, PictureName = "Assets\\Crustacea.jpg", Description = "Crustaceans form a large, diverse arthropod taxon which includes such animals as decapods, seed shrimp, branchiopods, fish lice, krill, remipedes, isopods, barnacles, copepods, amphipods and mantis shrimp. The crustacean group can be treated as a subphylum under the clade Mandibulata. It is now well accepted that the hexapods emerged deep in the Crustacean group, with the completed group referred to as Pancrustacea." },
               new { AnimalId = ++id, Name = "Microchaetus rappi", Age = 13, CategoryId = 6, PictureName = "Assets\\MicrochaetusRappi.jpg", Description = "Microchaetus rappi, the African giant earthworm, is a large earthworm in the Microchaetidae family, the largest of the segmented worms (commonly called earthworms). It averages about 1.4 m (4.5 ft) in length, but can reach a length of as much as 6.7 m (22 ft) and can weigh over 1.5 kg (3.3 lb)." },
               new { AnimalId = ++id, Name = "Decapodiformes", Age = 15, CategoryId = 6, PictureName = "Assets\\Decapodiformes.JPG", Description = "Decapodiformes is a superorder of Cephalopoda comprising all cephalopod species with ten limbs, specifically eight short arms and two long tentacles. It is hypothesized that the ancestral coleoid had five identical pairs of limbs, and that one branch of descendants evolved a modified arm pair IV to become the Decapodiformes, while another branch of descendants evolved and then eventually lost its arm pair II, becoming the Octopodiformes." },

               new { AnimalId = ++id, Name = "Frog", Age = 2, CategoryId = 5, PictureName = "Assets\\Frog.jfif", Description = "A frog is any member of a diverse and largely carnivorous group of short-bodied, tailless amphibians composing the order Anura (ανοὐρά, literally without tail in Ancient Greek). The oldest fossil \"proto-frog\" Triadobatrachus is known from the Early Triassic of Madagascar, but molecular clock dating suggests their split from other amphibians may extend further back to the Permian, 265 million years ago. Frogs are widely distributed, ranging from the tropics to subarctic regions, but the greatest concentration of species diversity is in tropical rainforest." },
               new { AnimalId = ++id, Name = "Salamander", Age = 1, CategoryId = 5, PictureName = "Assets\\Salamander.jfif", Description = "Salamanders are a group of amphibians typically characterized by their lizard-like appearance, with slender bodies, blunt snouts, short limbs projecting at right angles to the body, and the presence of a tail in both larvae and adults. All ten extant salamander families are grouped together under the order Urodela. Salamander diversity is highest in eastern North America, especially in the Appalachian Mountains; most species are found in the Holarctic realm, with some species present in the Neotropical realm." },
               new { AnimalId = ++id, Name = "Toad", Age = 0, CategoryId = 5, PictureName = "Assets\\Toad.jfif", Description = "Toad is a common name for certain frogs, especially of the family Bufonidae, that are characterized by dry, leathery skin, short legs, and large bumps covering the parotoid glands.", }
               );

            id = 0;
            int animalId = 0;
            model.Entity<Comment>().HasData(
                new { CommentId = ++id, AnimalId = ++animalId, CommentString = "Hey :)" },
                new { CommentId = ++id, AnimalId = animalId, CommentString = "So cute ;)" },
                new { CommentId = ++id, AnimalId = animalId, CommentString = "Dad" },
                new { CommentId = ++id, AnimalId = ++animalId, CommentString = "has been the industry's " },
                new { CommentId = ++id, AnimalId = ++animalId, CommentString = "Where does it come from?" },
                new { CommentId = ++id, AnimalId = animalId, CommentString = "Where can I get some?" },
                new { CommentId = ++id, AnimalId = ++animalId, CommentString = "Quisque ut sagittis." },
                new { CommentId = ++id, AnimalId = animalId, CommentString = "Vestibulum ante ipsum." },
                new { CommentId = ++id, AnimalId = animalId, CommentString = "asdasd " },
                new { CommentId = ++id, AnimalId = ++animalId, CommentString = "has been the industry's " },
                new { CommentId = ++id, AnimalId = ++animalId, CommentString = "has been the industry's " },
                new { CommentId = ++id, AnimalId = ++animalId, CommentString = "has been the industry's " },
                new { CommentId = ++id, AnimalId = ++animalId, CommentString = "has asd the c's " },
                new { CommentId = ++id, AnimalId = ++animalId, CommentString = "has been the industry's " },
                new { CommentId = ++id, AnimalId = ++animalId, CommentString = "has been the ewq's " },
                new { CommentId = ++id, AnimalId = ++animalId, CommentString = "has been the industry's " }
                );




        }
    }
}
