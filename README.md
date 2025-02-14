# PatikafyMusic

## Description
This C# program processes a dataset of musicians, genres, album sales, and release years using LINQ queries. The program extracts useful insights, such as filtering musicians based on their names, genres, sales, and release years.

---

## Features

### **1. Data Representation**
The program defines four lists:
- **`Musician`**: List of musician names.
- **`Genre`**: Corresponding music genre(s) for each musician.
- **`Year`**: The year of their first album release.
- **`Sales`**: Estimated album sales in millions.

### **2. Queries and Operations**

#### **📌 Musicians whose names start with 'S'**
```csharp
var S = Musician.Where(m => m.StartsWith("S")).ToList();
```
- Extracts all musicians whose names begin with the letter "S".

#### **📌 Musicians with over 10 million album sales**
```csharp
var Sales10 = Musician.Where((m,i) => Sales[i] > 10).ToList();
```
- Filters musicians with album sales exceeding 10 million.

#### **📌 Musicians who debuted before 2000 in the Pop genre**
```csharp
var Pop2000 = Musician
    .Select((m, i) => new { Name = m, Year = Year[i], Genre = Genre[i] })
    .Where(m => m.Year < 2000 && m.Genre == "Pop")
    .GroupBy(m => m.Year)
    .OrderBy(g => g.Key)
    .Select(g => new { Year = g.Key, Musicians = g.OrderBy(m => m.Name) })
    .ToList();
```
- Filters musicians who debuted **before 2000** and belong to the **Pop genre**.
- **Groups** them by **release year**.
- **Sorts** groups in ascending order by year.
- **Sorts** musicians within each group alphabetically.

#### **📌 Musician with the Highest Album Sales**
```csharp
var MaxSales = Musician[Sales.IndexOf(Sales.Max())];
```
- Identifies the musician with the highest album sales by finding the **index of the max sales value** in the `Sales` list.

#### **📌 Newest and Oldest Debut Musicians**
```csharp
var Newest = Musician[Year.IndexOf(Year.Max())];
var Oldest = Musician[Year.IndexOf(Year.Min())];
```
- Finds the musician with the **most recent debut** by identifying the maximum value in the `Year` list.
- Finds the musician with the **oldest debut** by identifying the minimum value in the `Year` list.

---

## **Example Output**
```
Adı 'S' ile başlayan şarkıcılar:
Sezen Aksu
Sertab Erener
Sıla
Serdar Ortaç

Albüm satışları 10 milyon'un üzerinde olan şarkıcılar:
Ajda Pekkan
Sezen Aksu
Tarkan

2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar:
Çıkış Yılı: 1968
  - Ajda Pekkan
Çıkış Yılı: 1992
  - Tarkan
Çıkış Yılı: 1994
  - Sertab Erener
Çıkış Yılı: 1999
  - Funda Arar
  - Hande Yener

En çok albüm satan şarkıcı:
Tarkan

En yeni çıkış yapan şarkıcı:
Sıla

En eski çıkış yapan şarkıcı:
Neşet Ertaş
```

---

## **Technologies Used**
- **C#**
- **.NET Core**
- **LINQ (Language Integrated Query)**

---

## **How to Run the Program**
1. Copy the source code into a **C# Console Application**.
2. Run the program to process and display the musician dataset.
3. Modify the dataset to analyze different musicians.

---

## **Possible Enhancements**
- Allow **user input** to filter by different genres or sales numbers.
- Display results in **graphical format** instead of console output.
- Save results to a **file or database**.
- Implement a **search feature** to find musicians dynamically.

---

This project demonstrates the power of **LINQ filtering, grouping, sorting, and indexing in C#**. 🚀

