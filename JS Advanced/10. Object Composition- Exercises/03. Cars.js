function carAssemble(car) {

  let engine;
  let carriage;
  let wheels = []

  if (car.power <= 90) {
    engine = {
      power: 90,
      volume: 1800
    }
  } else if (car.power <= 120) {
    engine = {
      power: 120,
      volume: 2400
    }
  } else {
    engine = {
      power: 200,
      volume: 3500
    }
  }

  carriage = {
    type: car.carriage,
    color: car.color
  }
  if (car.wheelsize % 2 == 0) {
    car.wheelsize--;
  }

  for (let i = 0; i < 4; i++) {
    wheels.push(car.wheelsize)
  }

  return {
    model: car.model,
    engine: engine,
    carriage: carriage,
    wheels: wheels
  }
  
}

console.log(carAssemble({
  model: 'VW Golf II',
  power: 90,
  color: 'blue',
  carriage: 'hatchback',
  wheelsize: 14
}));

console.log(carAssemble({
  model: 'Opel Vectra',
  power: 110,
  color: 'grey',
  carriage: 'coupe',
  wheelsize: 17
}));