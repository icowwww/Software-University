function solve(username,email,number,input) {
    input.forEach(line => {
        let userName = new RegExp('\<\\![a-zA-Z]+\\!\>', 'g');
        let emailReg = new RegExp('\<\\@[a-zA-Z]+\\@\>', 'g');
        let numberReg = new RegExp('\<\\+[a-zA-Z]+\\+\>', 'g');

        line = line.replace(userName, username);
        line = line.replace(emailReg, email);
        line = line.replace(numberReg, number);

        console.log(line);
    });
}