function solve() {

  let obj = {
    extend: function (template) {
      for (const key in template) {
        if (template.hasOwnProperty(key)) { //check to make sure that we iterate through object own keys, not the keys of it's prototype
          const element = template[key];
          if (typeof (element) === 'function') {
            obj.__proto__[key] = element;
          } else {
            obj[key] = element;
          }
        }
      }
    }
  }
  return obj;
}

//Test
let myObject = solve();
let template = {
  extensionMethod: function () {
    console.log('Ivan');
  },
  extensionProperty: 'someString'
}

myObject.extend(template);

console.log(myObject.__proto__);
console.log(myObject);