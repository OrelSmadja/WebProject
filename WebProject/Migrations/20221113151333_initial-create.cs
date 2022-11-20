using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebProject.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PictureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animals_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    CommentString = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Mammal" },
                    { 2, "Bird" },
                    { 3, "Fish" },
                    { 4, "Reptile" },
                    { 5, "Amphibians" },
                    { 6, "Invertebrates" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "CategoryId", "Description", "Name", "PictureName" },
                values: new object[,]
                {
                    { 1, 5, 1, "The dog  is a domesticated descendant of the wolf. Also called the domestic dog, it is derived from the extinct Pleistocene wolf, and the modern wolf is the dog's nearest living relative. The dog was the first species to be domesticated, by hunter-gatherers over 15,000 years ago, before the development of agriculture. Due to their long association with humans, dogs have expanded to a large number of domestic individuals and gained the ability to thrive on a starch-rich diet that would be inadequate for other canids.", "Dog", "Assets\\Dog.jfif" },
                    { 2, 2, 1, "The cat is a domestic species of small carnivorous mammal. It is the only domesticated species in the family Felidae and is commonly referred to as the domestic cat or house cat to distinguish it from the wild members of the family. A cat can either be a house cat, a farm cat, or a feral cat; the feral cat ranges freely and avoids human contact. Domestic cats are valued by humans for companionship and their ability to kill rodents. About 60 cat breeds are recognized by various cat registries.", "Cat", "Assets\\cat.jfif" },
                    { 3, 5, 1, "The proboscis monkey (Nasalis larvatus) or long-nosed monkey is an arboreal Old World monkey with an unusually large nose, a reddish-brown skin color and a long tail. It is endemic to the southeast Asian island of Borneo and is found mostly in mangrove forests and on the coastal areas of the island.", "Proboscis Monkey", "Assets\\ProboscisMonkey.jfif" },
                    { 4, 12, 1, "Dolphins range in size from the 1.7-metre-long (5 ft 7 in) and 50-kilogram (110-pound) Maui's dolphin to the 9.5 m (31 ft 2 in) and 10-tonne (11-short-ton) orca. Various species of dolphins exhibit sexual dimorphism where the males are larger than females. They have streamlined bodies and two limbs that are modified into flippers.", "Dolphin", "Assets\\Dolphin.jpeg" },
                    { 5, 3, 1, "The second largest order of mammals after rodents, bats comprise about 20% of all classified mammal species worldwide, with over 1,400 species. These were traditionally divided into two suborders: the largely fruit-eating megabats, and the echolocating microbats. But more recent evidence has supported dividing the order into Yinpterochiroptera and Yangochiroptera, with megabats as members of the former along with several species of microbats.", "Bat", "Assets\\Bat.jpeg" },
                    { 6, 3, 2, "The grey parrot (Psittacus erithacus), also known as the Congo grey parrot, Congo African grey parrot or African grey parrot, is an Old World parrot in the family Psittacidae. The Timneh parrot (Psittacus timneh) once was identified as a subspecies of the grey parrot, but has since been elevated to a full species.", "grey parrot", "Assets\\grayParrot.jpg" },
                    { 7, 12, 2, "Eagle is the common name for many large birds of prey of the family Accipitridae. Eagles belong to several groups of genera, some of which are closely related. Most of the 60 species of eagle are from Eurasia and Africa. Outside this area, just 14 species can be found—2 in North America, 9 in Central and South America, and 3 in Australia.", "Eagle", "Assets\\Eagle.jfif" },
                    { 8, 4, 2, "Corvus is a widely distributed genus of medium-sized to large birds in the family Corvidae. It includes species commonly known as crows, ravens and rooks. The species commonly encountered in Europe are the carrion crow, the hooded crow, the common raven and the rook; those discovered later were named \"crow\" or \"raven\" chiefly on the basis of their size, crows generally being smaller. The genus name is Latin for \"crow\".", "Corvus", "Assets\\Corvus.jpg" },
                    { 9, 15, 2, "Ciconia is a genus of birds in the stork family. Six of the seven living species occur in the Old World, but the maguari stork has a South American range. In addition, fossils suggest that Ciconia storks were somewhat more common in the tropical Americas in prehistoric times.", "Ciconia", "Assets\\Ciconia.jpg" },
                    { 10, 2, 3, "The Atlantic salmon (Salmo salar) is a species of ray-finned fish in the family Salmonidae. It is the third largest of the Salmonidae, behind Siberian taimen and Pacific Chinook salmon, growing up to a meter in length. Atlantic salmon are found in the northern Atlantic Ocean and in rivers that flow into it. Most populations are anadromous, hatching in streams and rivers but moving out to sea as they grow where they mature, after which the adults seasonally move upstream again to spawn.", "Salmon", "Assets\\Salmon.jfif" },
                    { 11, 1, 3, "Tetraodontidae is a family of primarily marine and estuarine fish of the order Tetraodontiformes. The family includes many familiar species variously called pufferfish, puffers, balloonfish, blowfish, blowies, bubblefish, globefish, swellfish, toadfish, toadies, toadle, honey toads, sugar toads, and sea squab.", "Tetraodontidae", "Assets\\Tetraodontidae.jfif" },
                    { 12, 1, 3, "A seahorse (also written sea-horse and sea horse) is any of 46 species of small marine fish in the genus Hippocampus. \"Hippocampus\" comes from the Ancient Greek hippókampos (ἱππόκαμπος), itself from híppos (ἵππος) meaning \"horse\" and kámpos (κάμπος) meaning \"sea monster\" or \"sea animal\"", "Hippocampus", "Assets\\Hippocampus.jpg" },
                    { 13, 3, 3, "The whiptail stingrays are a family, the Dasyatidae, of rays in the order Myliobatiformes. They are found worldwide in tropical to temperate marine waters, and a number of species have also penetrated into fresh water in Africa, Asia, and Australia. Members of this family have flattened pectoral fin discs that range from oval to diamond-like in shape. ", "Dasyatidae", "Assets\\Dasyatidae.jpg" },
                    { 14, 11, 4, "The Pythonidae, commonly known as pythons, are a family of nonvenomous snakes found in Africa, Asia, and Australia. Among its members are some of the largest snakes in the world. Ten genera and 42 species are currently recognized.", "Python Snake", "Assets\\PythonSnake.jfif" },
                    { 15, 5, 4, "Draco volans, also commonly known as the common flying dragon, is a species of lizard in the family Agamidae. The species is endemic to Southeast Asia.", "Draco Volans", "Assets\\DracoVolans.jfif" },
                    { 16, 22, 4, "An alligator is a large reptile in the Crocodilia order in the genus Alligator of the family Alligatoridae. The two extant species are the American alligator (A. mississippiensis) and the Chinese alligator (A. sinensis). Additionally, several extinct species of alligator are known from fossil remains. Alligators first appeared during the Oligocene epoch about 37 million years ago.[", "Alligator", "Assets\\Alligator.jfif" },
                    { 17, 45, 4, "Turtles are an order of reptiles known as Testudines, characterized by a shell developed mainly from their ribs. Modern turtles are divided into two major groups, the Pleurodira (side necked turtles) and Cryptodira (hidden necked turtles), which differ in the way the head retracts. ", "Turtle", "Assets\\Turtle.jfif" },
                    { 18, 20, 6, "Medusozoa is a clade in the phylum Cnidaria, and is often considered a subphylum. It includes the classes Hydrozoa, Scyphozoa, Staurozoa and Cubozoa, and possibly the parasitic Polypodiozoa. Medusozoans are distinguished by having a medusa stage in their often complex life cycle, a medusa typically being an umbrella-shaped body with stinging tentacles around the edge.", "Medusozoa ", "Assets\\Medusozoa.jpg" },
                    { 19, 4, 6, "Crustaceans form a large, diverse arthropod taxon which includes such animals as decapods, seed shrimp, branchiopods, fish lice, krill, remipedes, isopods, barnacles, copepods, amphipods and mantis shrimp. The crustacean group can be treated as a subphylum under the clade Mandibulata. It is now well accepted that the hexapods emerged deep in the Crustacean group, with the completed group referred to as Pancrustacea.", "Crustacea", "Assets\\Crustacea.jpg" },
                    { 20, 13, 6, "Microchaetus rappi, the African giant earthworm, is a large earthworm in the Microchaetidae family, the largest of the segmented worms (commonly called earthworms). It averages about 1.4 m (4.5 ft) in length, but can reach a length of as much as 6.7 m (22 ft) and can weigh over 1.5 kg (3.3 lb).", "Microchaetus rappi", "Assets\\MicrochaetusRappi.jpg" },
                    { 21, 15, 6, "Decapodiformes is a superorder of Cephalopoda comprising all cephalopod species with ten limbs, specifically eight short arms and two long tentacles. It is hypothesized that the ancestral coleoid had five identical pairs of limbs, and that one branch of descendants evolved a modified arm pair IV to become the Decapodiformes, while another branch of descendants evolved and then eventually lost its arm pair II, becoming the Octopodiformes.", "Decapodiformes", "Assets\\Decapodiformes.JPG" },
                    { 22, 2, 5, "A frog is any member of a diverse and largely carnivorous group of short-bodied, tailless amphibians composing the order Anura (ανοὐρά, literally without tail in Ancient Greek). The oldest fossil \"proto-frog\" Triadobatrachus is known from the Early Triassic of Madagascar, but molecular clock dating suggests their split from other amphibians may extend further back to the Permian, 265 million years ago. Frogs are widely distributed, ranging from the tropics to subarctic regions, but the greatest concentration of species diversity is in tropical rainforest.", "Frog", "Assets\\Frog.jfif" },
                    { 23, 1, 5, "Salamanders are a group of amphibians typically characterized by their lizard-like appearance, with slender bodies, blunt snouts, short limbs projecting at right angles to the body, and the presence of a tail in both larvae and adults. All ten extant salamander families are grouped together under the order Urodela. Salamander diversity is highest in eastern North America, especially in the Appalachian Mountains; most species are found in the Holarctic realm, with some species present in the Neotropical realm.", "Salamander", "Assets\\Salamander.jfif" },
                    { 24, 0, 5, "Toad is a common name for certain frogs, especially of the family Bufonidae, that are characterized by dry, leathery skin, short legs, and large bumps covering the parotoid glands.", "Toad", "Assets\\Toad.jfif" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "AnimalId", "CommentString" },
                values: new object[,]
                {
                    { 1, 1, "Hey :)" },
                    { 2, 1, "So cute ;)" },
                    { 3, 1, "Dad" },
                    { 4, 2, "" },
                    { 5, 3, "" },
                    { 6, 3, "" },
                    { 7, 4, "" },
                    { 8, 4, "" },
                    { 9, 4, "" },
                    { 10, 5, "" },
                    { 11, 6, "" },
                    { 12, 7, "" },
                    { 13, 8, "" },
                    { 14, 9, "" },
                    { 15, 10, "" },
                    { 16, 11, "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CategoryId",
                table: "Animals",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnimalId",
                table: "Comments",
                column: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
