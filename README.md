# Async Inn

*Author: Peyton Cysewski*

----

## Description
This program is an exercise in the ASP.NET Core framework to demonstrate the use of a database using fictional hotels. Visualized further below is an ERD that shows the relationships the data stored in the database. Each hotel is linked to a set of many hotel rooms. The hotel rooms are related to a base room that has an enumerated set of layouts. Each base room also is related to a set of groups of amenities that is further related to a set of all amenities.<br/>

This program uses a dependency injection implementation. Instead of having a universal controller, each controller that directs CRUD operations is abstracted through the part of the database that it interacts with. This allows for more long-term flexibilty and robustness at the cost of adding just a few extra abstraction layers.

---

### Getting Started
Clone this repository to your local machine.

```
$ git clone https://github.com/Peyton-Cysewski/Async-Inn.git
```

### To run the program from Visual Studio:
Select ```File``` -> ```Open``` -> ```Project/Solution```

Next navigate to the location you cloned the Repository.

Double click on the ```Async-Inn``` directory.

Then select and open ```Async-Inn.sln```

---

### Visuals

#### ERD (Credit to Amanda Iverson)
![Entity Relationship Diagram](./assets/ERD.png)

---

### Change Log
1.3 *Completed Repository Design* - 23 July 2020
1.2 *Implemented Dependency Injection* - 22 July 2020
1.1: *Initial Release* - 21 July 2020  