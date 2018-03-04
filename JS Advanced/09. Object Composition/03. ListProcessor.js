function solve(input) {

  let manipulator = (function () {

    let result = [];

    function add(word) {
      result.push(word);
    }

    function remove(word) {
      result = result.filter(e => e != word);
    }

    function print() {
     console.log(result.join(','));
    }

    return {
      add,
      remove,
      print
    }

  })();


  for (const inputLine of input) {
    let [command, word] = inputLine.split(' ');
    manipulator[command](word);
  }

}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);

solve(['add pesho', 'add gosho', 'add pesho', 'remove pesho', 'print']);
