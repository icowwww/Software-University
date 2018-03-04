function getModel() {

  let firstInput, secondInput, result

  function init(firstIdSelector, secondIdSelector, resultIdSelector) {
    firstInput = $(firstIdSelector);
    secondInput = $(secondIdSelector);
    result = $(resultIdSelector)
  }

  function add() {
    result.val(Number(firstInput.val()) + Number(secondInput.val()));
  }

  function subtract() {
    result.val(Number(firstInput.val()) - Number(secondInput.val()));
  }

  return {
    init,
    add,
    subtract
  }

}