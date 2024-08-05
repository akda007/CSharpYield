using System.Collections;

List<int> list = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];

var r = list.MyMap(x => x + 100);

foreach (var x in r) {
    Console.WriteLine(x);
}

Console.WriteLine($"Count: {list.MyCount()}");


public static class Extensions {

    public static IEnumerable<T> MySkip<T>(this IEnumerable<T> source, int count) {

        var it = source.GetEnumerator();
        for (int i = 0; i < count; i++) {
            it.MoveNext();
        }

        while (it.MoveNext()) {
            yield return it.Current;
        }
    }

    public static int MyCount<T>(this IEnumerable<T> source) {
        var it = source.GetEnumerator();
        int count = 0;
        while (it.MoveNext()) {
            count++;
        }

        return count;
    }

    public static T[] MyArray<T>(this IEnumerable<T> source) {
        var arr = new T[source.MyCount()];

        var it = source.GetEnumerator();
        int len = 0;
        while (it.MoveNext()) {
            arr[len++] = it.Current;
        }
        
        return arr;
    }

    public static IEnumerable<T> MyAppend<T>(this IEnumerable<T> source, T element) {
        var src = source.GetEnumerator();

        while (src.MoveNext()) {
            yield return src.Current;
        }

        yield return element;

    }

    public static IEnumerable<T> MyPrepend<T>(this IEnumerable<T> source, T element) {
        var src = source.GetEnumerator();
        
        yield return element;

        while (src.MoveNext()) {
            yield return src.Current;
        }
    }

    public static bool Empty<T>(this IEnumerable<T> source) 
        => source.GetEnumerator().MoveNext();

    public static T? MyFirstOrDefault<T> (this IEnumerable<T> source) {
        var it = source.GetEnumerator();

        return it.MoveNext() ? it.Current : default;
    }

    public static IEnumerable<T> MyFilter<T>(this IEnumerable<T> source, Func<T, bool> filter) {
        var it = source.GetEnumerator();

        while (it.MoveNext()) {
            if (filter(it.Current))
                yield return it.Current;
        }
    }


    public static IEnumerable<T[]> MyChunk<T>(this IEnumerable<T> source, int size) {
        var arr = new T[size];

        var it = source.GetEnumerator();
        int index = 0;
        while (it.MoveNext()) {
            arr[index++] = it.Current;

            if (index == size) {
                yield return arr;
                arr = new T[size];
            }
        }
    }

    public static IEnumerable<TR> MyMap<T, TR>(this IEnumerable<T> source, Func<T, TR> mapFunc) {
        var it = source.GetEnumerator();

        while (it.MoveNext()) {
            yield return mapFunc(it.Current);
        }
    }

     public static IEnumerable<T> MySort<T>(this IEnumerable<T> source)
        where T : IComparable
    {
        var list = new List<T>();
        var it = source.GetEnumerator();
        
    }

    public static bool BinaryContains<T>(this IEnumerable<T> source)
        where T : IComparable
    {

    }
}

