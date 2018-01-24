function solve(input) {
    for(i=0; i<input.length; i+=2){
        let x = parseFloat(input[i])
        let y = parseFloat(input[i+1])
        if (x<=3 && x>=1 && y <=3 && y>=1)
            console.log('Tuvalu')
        else if(x<=9 && x>=8 && y<=1 && y>=0)
            console.log('Tokelau')
        else if(x<=2 && x>=0 && y<=8 && y>=6)
            console.log('Tonga')
        else if(x<=7 && x>=5 && y<=6 && y>=3)
            console.log('Samoa')
        else if(x<=9 && x>=4 && y<=8 && y>=7)
            console.log('Cook')
        else
            console.log('On the bottom of the ocean')
    }
}