function solve(arr) {
    arr.sort(CompareForSort)
    console.log(arr[0] + ' ' + arr[1])

    function CompareForSort(first, second)
    {
        if (first == second)
            return 0;
        if (first < second)
            return -1;
        else
            return 1;
    }
}