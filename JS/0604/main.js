// import { create, createReportList, clear } from "./modules/canvas.js";
import * as Canvas from "./modules/canvas.js"; //全部取要加別名
import { name, draw, reportArea, reportPerimeter } from "./modules/square.js";
import randomSquare from "./modules/square.js";

const createSquareBtn = document.querySelector("#create-square-btn");
const clearBtn = document.querySelector("#clear-btn");

let myCanvas = Canvas.create("my-canvas", document.body, 480, 320);
let reportList = Canvas.createReportList(myCanvas.id);

let square1 = draw(myCanvas.ctx, 50, 50, 100, "blue");
reportArea(square1.length, reportList);
reportPerimeter(square1.length, reportList);

//USE Default
let square2 = randomSquare(myCanvas.ctx);

clearBtn.addEventListener("click", () => {
  Canvas.clear(myCanvas.ctx);
});

createSquareBtn.addEventListener("click", () => {
  const square = randomSquare(myCanvas.ctx);

  reportArea(square.length, reportList);
  reportPerimeter(square.length, reportList);
});
