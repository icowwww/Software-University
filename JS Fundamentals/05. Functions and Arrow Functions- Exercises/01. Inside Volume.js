function solve(input) {
    for (i=0; i< input.length; i+=3){
        let x = input[i]
        let y = input[i+1]
        let z = input[i+2]

        function inVolume(x, y, z) {
            let x1 = 10
            let x2 = 50
            let y1 = 20
            let y2 = 80
            let z1 = 15
            let z2 = 50

            if (x >= x1 && x <= x2)
                if (y >= y1 && y <= y2)
                    if (z >= z1 && z <= z2)
                        return true
            return false
        }
        if (inVolume(x,y,z))
            console.log('inside')
        else
            console.log('outside')
    }
}