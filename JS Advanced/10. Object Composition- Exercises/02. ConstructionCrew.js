function drunkWorkers(worker) {

  if (worker.handsShaking === true) {
    let modifiedWorker = {
      weight: worker.weight,
      experience: worker.experience,
      bloodAlcoholLevel: worker.bloodAlcoholLevel + worker.weight * worker.experience * 0.1,
      handsShaking: false
    }

    return modifiedWorker;
  }
  return worker;
}

console.log(drunkWorkers({
  weight: 120,
  experience: 20,
  bloodAlcoholLevel: 200,
  handsShaking: true
}));