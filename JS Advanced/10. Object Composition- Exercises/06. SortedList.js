function solve() {

    let arr = [];

    let obj = {
        add: function add(element) {
            
            arr.push(element);
            arr.sort((a, b) => a - b);
            this.size++;
        },
        remove: function remove(index) {

            if (index >= 0 && index < arr.length) {
                arr.splice(index, 1);
                this.size--;
            }
        },
        get: function get(index) {

            if (index >= 0 && index < arr.length) {

              return(arr[index]);
            }
        },

        size: 0
    }
    return obj;
}


let sorted = solve();

sorted.add('5');
sorted.add('3');
sorted.add('-2');
sorted.remove(0);
sorted.get('0');
console.log(sorted.size);