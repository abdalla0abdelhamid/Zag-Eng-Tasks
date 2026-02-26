namespace LINQTask;

internal class Program
{
    static void Main(string[] args)
    {
        //Q1
        //List<int> numbers = [3, 18, 7, 42, 10, 5, 29, 14, 6, 100];

        //// TODO: Write the query using Query Syntax
        //var querySyntax = from n in numbers
        //                  where n > 10 && n % 2 == 0
        //                  orderby n descending
        //                  select n;

        //// TODO: Write the same query using Fluent Syntax
        //var fluentSyntax = numbers
        //                  .Where(n => n > 10 && n % 2 == 0)
        //                  .OrderByDescending(n => n);

        //// Expected output: 100, 42, 18, 14
        //Console.WriteLine(string.Join(", ", querySyntax));
        //Console.WriteLine(string.Join(", ", fluentSyntax));

        //***********************************************************************
        //Q2
        //record Product(int Id, string Name, decimal Price, string Category);

        //List<Product> products = [
        //    new(1, "Laptop", 1200m, "Electronics"),
        //                new(2, "Phone", 800m, "Electronics"),
        //                new(3, "Desk", 350m, "Furniture"),
        //                new(4, "Chair", 150m, "Furniture"),
        //                new(5, "Headphones", 200m, "Electronics"),
        //];

        //// 1. Get the first Electronics product
        //var firstElectronics = products.First(p => p.Category == "Electronics");

        //// 2. Get the last product with Price > 1000 (use OrDefault — handle null)
        //var lastExpensive = products.LastOrDefault(p => p.Price > 1000);
        //if (lastExpensive != null)
        //{
        //    Console.WriteLine($"Last Expensive: {lastExpensive.Name}");
        //}
        //else
        //{
        //    Console.WriteLine("No expensive product found.");
        //}

        //// 3. Get the single Furniture item with Price > 300 (what if >1 match?)
        //try
        //{
        //    // Desk is 350, Chair is 150. Only one match exists here.
        //    var singleFurniture = products.Single(p => p.Category == "Furniture" && p.Price > 300);
        //    Console.WriteLine($"Single Furniture: {singleFurniture.Name}");
        //}
        //catch (InvalidOperationException ex)
        //{
        //    Console.WriteLine($"Exception handled: {ex.Message}");
        //}

        //// 4. Get the element at index 3
        //var elementAtIndex3 = products.ElementAt(3);
        //Console.WriteLine($"Element at 3: {elementAtIndex3.Name}");

        //************************************************************************
        //Q3
        // Using the products list from Q2

        // 1. Are ALL products priced above 100? → bool
        //bool allAbove100 = products.All(p => p.Price > 100);
        //Console.WriteLine($"1. All products > 100: {allAbove100}");

        //// 2. Is THERE ANY product in the "Gaming" category? → bool
        //bool anyGaming = products.Any(p => p.Category == "Gaming");
        //Console.WriteLine($"2. Any Gaming product: {anyGaming}");

        //// 3. Does the collection CONTAIN a product named "Chair"?
        //// (use the default comparer on the record)
        //var chairProduct = new Product(0, "Chair", 0, ""); 
        //bool containsChair = products.Contains(new Product(4, "Chair", 150m, "Furniture"));
        //Console.WriteLine($"3. Contains Chair (exact match): {containsChair}");

        //// 4. Are ALL Electronics products priced above 500? → bool
        //bool allElectronicsAbove500 = products.Where(p => p.Category == "Electronics").All(p => p.Price > 500);
        //Console.WriteLine($"4. All Electronics > 500: {allElectronicsAbove500}");

        //// 5. Is there ANY product cheaper than 200? → bool
        //bool anyCheaperThan200 = products.Any(p => p.Price < 200);
        //Console.WriteLine($"5. Any product < 200: {anyCheaperThan200}");

        //************************************************************************
        //Q4
        //// 1. Convert to Array
        //var productsArray = products.ToArray();

        //// 2. Convert to Dictionary keyed by Id
        //var productsDict = products.ToDictionary(p => p.Id);

        //// 3. Convert to HashSet of product Names
        //var productsNamesSet = products.Select(p => p.Name).ToHashSet();

        //// 4. Convert to Lookup keyed by Category
        //var productsLookup = products.ToLookup(p => p.Category);
        //var electronics = productsLookup["Electronics"];

        //************************************************************************
        //Q5
        //    List<string> orders = ["ORD-001", "ORD-002", "ORD-003", "ORD-004", "ORD-005", "ORD-006", "ORD-007"];
        //    int pageSize = 3;

        //    // 1. Get Page 1 (items 1–3)
        //    var page1 = orders.Skip(0).Take(pageSize).ToList();

        //    // 2. Get Page 2 (items 4–6) ← use Skip + Take
        //    var page2 = orders.Skip(pageSize).Take(pageSize).ToList();

        //    // 3. Get the last 2 orders using TakeLast
        //    var last2Orders = orders.TakeLast(2).ToList();

        //    // 4. Drop the first and last order using Skip + SkipLast
        //    var middleOrders = orders.Skip(1).SkipLast(1).ToList();

        //public static List<T> Paginate<T>(IEnumerable<T> source, int pageNumber, int pageSize)
        //{
        //    return source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        //}

        //************************************************************************
        //Q6

        //            record Employee(string Name, string Department, decimal Salary);

        //            List<Employee> employees = [
        //                new("Ali", "Engineering", 9000m),
        //    new("Sara", "Engineering", 8500m),
        //    new("Omar", "HR", 6000m),
        //    new("Mona", "HR", 6200m),
        //    new("Yara", "Marketing", 7000m),
        //    new("Karim", "Marketing", 7500m),
        //    new("Nada", "Engineering", 9500m),
        //];

        //            // 1. Project to anonymous type: { FullName = Name.ToUpper(), Salary }
        //            var anonProjection = employees.Select(e => new { FullName = e.Name.ToUpper(), e.Salary }).ToList();

        //            // 2. Project to a formatted string: "Ali works in Engineering — EGP 9,000"
        //            var stringProjection = employees.Select(e => $"{e.Name} works in {e.Department} — EGP {e.Salary:N0}").ToList();

        //            // 3. Sort by Salary descending, then use indexed Select to add Rank
        //            var rankedEmployees = employees
        //                .OrderByDescending(e => e.Salary)
        //                .Select((e, index) => new
        //                {
        //                    Rank = index + 1,
        //                    e.Name,
        //                    e.Salary,
        //                    SeniorityLevel = e.Salary >= 9000 ? "Senior" : (e.Salary >= 7000 ? "Mid" : "Junior")
        //                }).ToList();
        //        }

        //************************************************************************
        //Q7
        //List<int> scores = [88, 92, 75, 60, 55, 80, 91, 45];

        //// 1. TakeWhile score >= 70 → expected: [88, 92, 75]
        //var takeWhileResult = scores.TakeWhile(s => s >= 70).ToList();

        //// 2. SkipWhile score >= 70 → expected: [60, 55, 80, 91, 45]
        //var skipWhileResult = scores.SkipWhile(s => s >= 70).ToList();

        //************************************************************************
        //Q8
        // Using employees list from Q6/Q8
        // 1. Group by Department, print: "Engineering → Count: 3, Avg: 9000"
        //var groupedByDept = employees.GroupBy(e => e.Department);
        //foreach (var group in groupedByDept)
        //{
        //    Console.WriteLine($"{group.Key} → Count: {group.Count()}, Avg: {group.Average(e => e.Salary)}");
        //}

        //// 2. Find the department with the highest total salary budget
        //var deptHighestBudget = groupedByDept
        //    .OrderByDescending(g => g.Sum(e => e.Salary))
        //    .First().Key;

        //// 3. List employees in each group ordered by Salary descending
        //var employeesOrderedInGroups = groupedByDept
        //    .Select(g => new { Department = g.Key, Employees = g.OrderByDescending(e => e.Salary).ToList() });

        //************************************************************************
        //Q9
        //List<int> nums = [1, 2, 3, 4, 5];
        //var query = nums.Where(n => n > 2); // ← query defined here
        //nums.Add(10); // ← source modified AFTER query
        //foreach (var n in query) Console.Write(n + " ");

        // Q: What is printed? Why?
        // جواب: سيتم طباعة: 3 4 5 10
        // السبب: لأن تنفيذ LINQ مؤجل (Deferred Execution). عند الوصول للـ foreach، يتم قراءة القائمة الأصلية مرة أخرى،
        // وبما أننا أضفنا 10 قبل الـ foreach، فإنها ستظهر في النتيجة.

        // Q: How would using .ToList() right after .Where(...) change the result?
        // جواب: إذا استخدمنا .ToList() فورًا، سيتم تنفيذ الاستعلام فورًا وتخزين النتائج (3, 4, 5) فقط.
        // إضافة 10 لاحقًا لن تؤثر على النتيجة المطبوعة.

        // Q: Name 3 LINQ operators that trigger immediate execution.
        // جواب: ToList(), ToArray(), Count(), First(), Sum() (أي 3 منهم).

        //************************************************************************
        //Q10
        //List<string> words = ["apple", "fig", "banana", "kiwi", "grape", "mango", "pear", "plum"];

        // 1. Filter words longer than 4 characters
        //var longerThan4 = words.Where(w => w.Length > 4).ToList();

        // 2. Filter words at even indexes (0, 2, 4, 6...) using (item, index) overload
        //var evenIndexes = words.Where((w, i) => i % 2 == 0).ToList();

        // 3. Filter words that are BOTH longer than 4 chars AND at an even index
        //var bothConditions = words.Where((w, i) => w.Length > 4 && i % 2 == 0).ToList();

        // 4. What is the index of "mango" in the filtered result from step 1?
        // الكلمات الأطول من 4 أحرف: apple(0), banana(1), grape(2), mango(3).
        // جواب: Index هو 3.

        //************************************************************************
        //Q11
        //        record Course(string Title, List<string> Students);

        //        List<Course> courses = [
        //            new("C# Basics", ["Ali", "Sara", "Omar"]),
        //    new("LINQ Mastery", ["Sara", "Mona", "Ali"]),
        //    new("ASP.NET Core", ["Yara", "Omar", "Karim"]),
        //];

        //        // 1. Flatten to a single list of ALL student names (with duplicates)
        //        var allStudents = courses.SelectMany(c => c.Students).ToList();

        //        // 2. Get a distinct list of all student names
        //        var distinctStudents = courses.SelectMany(c => c.Students).Distinct().ToList();

        //        // 3. Find students who appear in MORE THAN ONE course
        //        var studentsInMultipleCourses = courses
        //            .SelectMany(c => c.Students)
        //            .GroupBy(s => s)
        //            .Where(g => g.Count() > 1)
        //            .Select(g => g.Key)
        //            .ToList();

        //        // 4. Use SelectMany with result selector to get (CourseName, StudentName) pairs
        //        var pairs = courses.SelectMany(
        //            c => c.Students,
        //            (course, student) => new { CourseName = course.Title, StudentName = student }
        //        ).ToList();

        //************************************************************************
        //Q12
        // 1. From employees: get the TOP 2 highest-paid employees per department.
        // → Use GroupBy + OrderByDescending + Take(2) inside each group
        // → Flatten the result with SelectMany
        //var top2PerDept = employees
        //    .GroupBy(e => e.Department)
        //    .SelectMany(g => g
        //        .OrderByDescending(e => e.Salary)
        //        .Take(2)
        //        .Select((e, index) => new {
        //            Dept = g.Key,
        //            Employee = e,
        //            Rank = index + 1
        //        })
        //    )
        //    .ToList();
        //// تنفيذ مؤجل (Deferred) حتى يتم استدعاء ToList() في النهاية.

        //// 2. From courses: build a Dictionary<string, int> of { CourseName → StudentCount }, but only for courses with > 2 students.
        //var courseDict = courses
        //    .Where(c => c.Students.Count > 2)
        //    .ToDictionary(c => c.Title, c => c.Students.Count);
        //// تنفيذ فوري (Immediate) بسبب ToDictionary().

        //// 3. Check:
        //// ⟢ Does ANY employee in Engineering earn less than 8000?
        //bool anyEngLessThan8000 = employees
        //    .Where(e => e.Department == "Engineering")
        //    .Any(e => e.Salary < 8000); // تنفيذ مؤجل حتى Any()

        //// ⟢ Do ALL HR employees earn more than 5500?
        //bool allHRMoreThan5500 = employees
        //    .Where(e => e.Department == "HR")
        //    .All(e => e.Salary > 5500); // تنفيذ مؤجل حتى All()

        //// 4. Project the top-2-per-dept result into: { Rank, Name, Department, Salary, SeniorityLevel }
        //// where Rank resets per department (use indexed Select per group).
        //var projectedTop2 = employees
        //    .GroupBy(e => e.Department)
        //    .SelectMany(g => g
        //        .OrderByDescending(e => e.Salary)
        //        .Take(2)
        //        .Select((e, index) => new
        //        {
        //            Rank = index + 1,
        //            e.Name,
        //            Department = g.Key,
        //            e.Salary,
        //            SeniorityLevel = e.Salary >= 9000 ? "Senior" : (e.Salary >= 7000 ? "Mid" : "Junior")
        //        })
        //    ).ToList();
        // تنفيذ مؤجل (Deferred) خلال الـ Query، وفوري (Immediate) عند .ToList().

        // 5. For each step above — is execution deferred or immediate?
        // مكتوب كـ comments inline فوق كل كود في النقاط السابقة.
    }
}