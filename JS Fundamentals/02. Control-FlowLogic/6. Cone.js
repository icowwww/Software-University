function coneArea(a,h) {
    let v = ((Math.PI*a*a)*h) / 3
    console.log(v)
    let s = Math.sqrt(a*a + h*h)
    let area= Math.PI*s*a + Math.PI*a*a
    console.log(area)
}