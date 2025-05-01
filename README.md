##BG

За да се стартира проекта - 
Можете да клонирате кода от github направо в някое IDE или да го свалите в ZIP файл и оттам да си го стартирате (отваряте .sln файла).

При стартиране на проекта -
Трябва да се създаде база данни с името CRUDTestDB.
Да се напише командата Update-Database в Package Manager Console.
След това можете да стартирате програмата.

Как работи програмата - 
При натискане на бутона Load Data, програмата взима данни от "https://jsonplaceholder.typicode.com/users".
Тези данни автоматично се попълват в таблица със съотвените колони и редове според данните.
Можете да напишете какъвто и да е вид текст в Note или да се маркира чекбокса IsActive.
При натискане на бутона Save All, всички предишни данни се изтриват, като се запазват новите данни.
* Има и опция да се запазват само данните, които са нови или са променени без да се афектират непроменените данни.
Данните се запазват в CRUDTestDB.

##ENG

How to start the project - 
You can clone the code from the github repository in an IDE of your choice OR
You can download the code in a ZIP file and then extract it. When extracted, just open the .sln.

Before running the project - 
You need to create a database with the name CRUDTestDB.
After that, type in the Package Manager Console - Update-Database
After that you can start the program.

How does the program work - 
When you press the button Load Data, the program gets data from "https://jsonplaceholder.typicode.com/users".
That data is automatically filled in a table with the rows and columns appropriate for the data.
You can type whatever text you want in Note field or check/uncheck the checkbox IsActive.
When you press the button SaveAll, all previous data is being deleted and the new data is saved.
* There is an option only the updated or the new data to be saved without affecting non-changed data.
The data is saved in CRUDTestDB.
