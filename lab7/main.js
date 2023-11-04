// переменная, в которой хранится выбранное математическое действие
//var operation;
//var numFirst = Number(document.getElementById("numFirst").value);
//var numSec = Number(document.getElementById("numSec").value);
// функция расчёта
// function func() {
// 	// переменная для результата
// 	var result;
// 	// получаем первое и второе число

// 	// смотрим, что было в переменной с действием, и действуем исходя из этого
// 	switch (operation) {
// 		case "+":
// 			result = numFirst + numSec;
// 			break;
// 		case "-":
// 			result = numFirst - numSec;
// 			break;
// 		case "*":
// 			result = numFirst * numSec;
// 			break;
// 		case "/":
// 			result = numFirst / numSec;
// 			break;
// 	}
// 	document.getElementById("result").innerHTML = result;
// }

const plus = (numFirst, numSec) => +numFirst + +numSec;
const minus = (numFirst, numSec) => +numFirst - +numSec;
const mul = (numFirst, numSec) => +numFirst * +numSec;
const divide = (numFirst, numSec) => +numFirst / +numSec;
const validateNum = (numFirst, numSec) => {
	return !(isNaN(numFirst) || isNaN(numSec));
};
const emptyField = (numFirst, numSec) => {
	return !(numFirst == "" || numSec == "");
};

module.exports = { plus, minus, mul, divide, validateNum, emptyField };
