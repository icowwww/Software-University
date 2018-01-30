function orbit(input) {
    let rows = input[0]
    let cols = input[1]
    let starRow = input[2]
    let starCol = input[3]


    let matrix = [];
    for (let i = 0; i < rows; i++){
        matrix.push([]);
        for (let j = 0; j < cols; j++){
            matrix[i].push(0);
        }
    }

    let element = 1;
    // Fill star cell
    matrix[starRow][starCol] = element;

    let startRow = starRow - 1;
    let startCol = starCol - 1;
    let endRow = starRow + 1;
    let endCol = starCol + 1;

    while (startRow >= 0 || startCol >= 0 || endRow <= matrix.length - 1 || endCol <= matrix[0].length){
        element++;
        if (startRow >= 0){
            matrix[startRow].fill(element);
        }
        if (endRow <= matrix.length - 1){
            matrix[endRow].fill(element);
        }

        if (startCol >= 0){
            let sR = Math.max(startRow, 0);
            let eR = Math.min(endRow, matrix.length - 1);
            for (let r = sR; r <= eR; r++){
                matrix[r][startCol] = element;
            }
        }

        if (endCol <= matrix[0].length - 1){
            let sR = Math.max(startRow, 0);
            let eR = Math.min(endRow, matrix.length - 1);
            for (let r = sR; r <= eR; r++){
                matrix[r][endCol] = element;
            }
        }

        startRow--;
        startCol--;
        endRow++;
        endCol++;
    }

    console.log(matrix.map(
        row => row.join(' ')
    ).join('\n'));
}