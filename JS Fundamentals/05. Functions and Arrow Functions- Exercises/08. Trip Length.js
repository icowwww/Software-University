function shortestSegment(coor) {

    let distance12 = getDistance(coor[0], coor[1], coor[2], coor[3]);
    let distance13 = getDistance(coor[0], coor[1], coor[4], coor[5]);
    let distance23 = getDistance(coor[2], coor[3], coor[4], coor[5]);

    if ((distance12 <= distance13) && (distance13 => distance23)) {
        let a = distance12 + distance23;
        console.log('1->2->3: ' + a);
    }
    else if ((distance12 <= distance23) && (distance13 < distance23)) {
        let b = distance13 + distance12;
        console.log('2->1->3: '+ b);
    }
    else {
        let c = distance23 + distance13;
        console.log('1->3->2: ' + c);
    }
    function getDistance(x1, y1, x2, y2) {

        let dist = Math.sqrt((x2 - x1) ** 2 + (y2 - y1) ** 2);
        return dist;
    }
}