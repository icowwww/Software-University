function getFibonacciNumber() {

  let fisrtNumber = 0;
  let secondNumber = 1;

  return () => {

    currentNumber = fisrtNumber + secondNumber;
    fisrtNumber = secondNumber;
    secondNumber = currentNumber;
    return (fisrtNumber);
  }
}