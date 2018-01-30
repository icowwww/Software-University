function solve(arr) {
    arr.sort(CompareForSort)
    return arr.join('\n')

    function CompareForSort(first, second)
    {
        if (first.length === second.length){
            if (first === second)
                return 0;
            if (first < second)
                return -1;
            else
                return 1;
        }
        if (first.length < second.length)
            return -1
        else
            return 1
    }
}
