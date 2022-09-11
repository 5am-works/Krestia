type DrawFunction = (
  ctx: Path2D,
  height: number,
  width: number,
  x: number,
  y: number
) => void;

const m: DrawFunction = (ctx, height, width, x, y) => {
  ctx.lineTo(x, y + height);
  ctx.lineTo(x + width, y + height);
};

const p: DrawFunction = (ctx, height, width, x, y) => {
  ctx.moveTo(x, y + height);
  ctx.lineTo(x, y);
  ctx.lineTo(x + width, y);
};

const k: DrawFunction = (ctx, height, width, x, y) => {
  ctx.lineTo(x + width, y);
  ctx.lineTo(x + width, y + height);
};

const noun: DrawFunction = (ctx, height, width, x, y) => {
  ctx.moveTo(x + width, y);
  ctx.lineTo(x, y + height / 2);
  ctx.lineTo(x + width, y + height);
  ctx.moveTo(x, y + height / 2);
  ctx.lineTo(x + width, y + height / 2);
};

const drawFunctions = new Map<string, DrawFunction>([
  ["p", p],
  [
    "b",
    (ctx, height, width, x, y) => {
      ctx.moveTo(x, y + height);
      ctx.lineTo(x, y);
      ctx.lineTo(x + width, y);
      ctx.moveTo(x + width / 3, y);
      ctx.lineTo(x + width / 3, y + height);
    },
  ],
  ["m", m],
  [
    "v",
    (ctx, height, width, x, y) => {
      ctx.moveTo(x + width, y);
      ctx.lineTo(x, y);
      ctx.lineTo(x + width / 2, y + height);
    },
  ],
  [
    "t",
    (ctx, height, width, x, y) => {
      ctx.lineTo(x + width, y);
      ctx.moveTo(x + width / 2, y);
      ctx.lineTo(x + width / 2, y + height);
    },
  ],
  [
    "d",
    (ctx, height, width, x, y) => {
      if (width < 10) {
        ctx.moveTo(x, y + height);
        ctx.lineTo(x, y);
        ctx.lineTo(x + width, y);
        ctx.lineTo(x + width, y + height);
      } else {
        ctx.lineTo(x + width, y);
        ctx.moveTo(x + width / 3, y);
        ctx.lineTo(x + width / 3, y + height);
        ctx.moveTo(x + (width * 2) / 3, y);
        ctx.lineTo(x + (width * 2) / 3, y + height);
      }
    },
  ],
  [
    "n",
    (ctx, height, width, x, y) => {
      ctx.moveTo(x + width / 2, y);
      ctx.lineTo(x + width / 2, y + height);
      ctx.moveTo(x, y + height);
      ctx.lineTo(x + width, y + height);
    },
  ],
  [
    "s",
    (ctx, height, width, x, y) => {
      ctx.lineTo(x + width, y);
      ctx.moveTo(x + width / 2, y);
      ctx.lineTo(x, y + height);
      ctx.moveTo(x + width / 2, y);
      ctx.lineTo(x + width, y + height);
    },
  ],
  [
    "l",
    (ctx, height, width, x, y) => {
      ctx.lineTo(x + width, y);
      ctx.lineTo(x + width, y + height);
      ctx.lineTo(x, y + height);
      ctx.lineTo(x, y);
    },
  ],
  [
    "r",
    (ctx, height, width, x, y) => {
      ctx.lineTo(x + width, y);
      ctx.lineTo(x + width / 2, y + height);
      ctx.lineTo(x, y);
    },
  ],
  [
    "j",
    (ctx, height, width, x, y) => {
      ctx.lineTo(x + width, y);
      ctx.moveTo(x + width / 2, y);
      ctx.lineTo(x + width / 2, y + height);
      ctx.moveTo(x, y + height);
      ctx.lineTo(x + width, y + height);
    },
  ],
  ["k", k],
  [
    "g",
    (ctx, height, width, x, y) => {
      ctx.lineTo(x + width, y);
      ctx.lineTo(x + width, y + height);
      ctx.moveTo(x + (width < 10 ? width / 5 : (width * 2) / 3), y);
      ctx.lineTo(x + (width < 10 ? width / 5 : (width * 2) / 3), y + height);
    },
  ],
  [
    "w",
    (ctx, height, width, x, y) => {
      ctx.moveTo(x + width, y + height / 2);
      ctx.ellipse(
        x + width / 2,
        y + height / 2,
        width / 2,
        height / 2,
        0,
        0,
        360
      );
    },
  ],
  [
    "h",
    (ctx, height, width, x, y) => {
      ctx.lineTo(x + width, y);
      ctx.moveTo(x, y + height);
      ctx.lineTo(x + width, y + height);
    },
  ],
  ["i", p],
  [
    "e",
    (ctx, height, width, x, y) => {
      ctx.lineTo(x, y + height);
      ctx.moveTo(x, y + height / 2);
      ctx.lineTo(x + width, y + height / 2);
    },
  ],
  ["a", m],
  ["u", k],
  [
    "o",
    (ctx, height, width, x, y) => {
      ctx.moveTo(x, y + height / 2);
      ctx.lineTo(x + width, y + height / 2);
      ctx.moveTo(x + width, y);
      ctx.lineTo(x + width, y + height);
    },
  ],
  [
    "ɒ",
    (ctx, height, width, x, y) => {
      ctx.moveTo(x, y + height);
      ctx.lineTo(x + width, y + height);
      ctx.lineTo(x + width, y);
    },
  ],
  [
    "pl",
    (ctx, height, width, x, y) => {
      ctx.moveTo(x, y + height);
      ctx.lineTo(x, y);
      ctx.lineTo(x + width, y);
      ctx.lineTo(x + width, y + height);
      ctx.lineTo(x + (width * 2) / 3, y + height);
      ctx.lineTo(x + (width * 2) / 3, y);
    },
  ],
  [
    "pr",
    (ctx, height, width, x, y) => {
      ctx.moveTo(x, y + height);
      ctx.lineTo(x, y);
      ctx.lineTo(x + width, y);
      ctx.lineTo((x * 3) / 4, y + height);
      ctx.lineTo(x / 2, y);
    },
  ],
  [
    "bl",
    (ctx, height, width, x, y) => {
      ctx.moveTo(x, y + height);
      ctx.lineTo(x, y);
      ctx.lineTo(x + width, y);
      ctx.lineTo(x + width, y + height);
      ctx.lineTo(x + (width * 2) / 3, y + height);
      ctx.lineTo(x + (width * 2) / 3, y);
      ctx.moveTo(x + width / 3, y);
      ctx.lineTo(x + width / 3, y + height);
    },
  ],
  [
    "br",
    (ctx, height, width, x, y) => {
      ctx.moveTo(x, y + height);
      ctx.lineTo(x, y);
      ctx.lineTo(x + width, y);
      ctx.lineTo(x + (width * 5) / 6, y + height);
      ctx.lineTo(x + (width * 2) / 3, y);
      ctx.moveTo(x + width / 3, y);
      ctx.lineTo(x + width / 3, y + height);
    },
  ],
  [
    "tl",
    (ctx, height, width, x, y) => {
      ctx.lineTo(x + width, y);
      ctx.moveTo(x + width / 3, y);
      ctx.lineTo(x + width / 3, y + height);
      ctx.lineTo(x + (width * 2) / 3, y + height);
      ctx.lineTo(x + (width * 2) / 3, y);
    },
  ],
  [
    "tr",
    (ctx, height, width, x, y) => {
      ctx.lineTo(x + width, y);
      ctx.moveTo(x + width / 4, y);
      ctx.lineTo(x + width / 2, y + height);
      ctx.lineTo(x + (width * 3) / 4, y);
    },
  ],
  [
    "dl",
    (ctx, height, width, x, y) => {
      ctx.moveTo(x + width / 3, y);
      ctx.lineTo(x + width / 3, y + height);
      ctx.lineTo(x, y + height);
      ctx.lineTo(x, y);
      ctx.lineTo(x + width, y);
      ctx.lineTo(x + width, y + height);
      ctx.lineTo(x + (width * 2) / 3, y + height);
      ctx.lineTo(x + (width * 2) / 3, y);
    },
  ],
  [
    "dr",
    (ctx, height, width, x, y) => {
      ctx.moveTo(x + width / 3, y);
      ctx.lineTo(x + width / 3, y + height);
      ctx.lineTo(x, y);
      ctx.lineTo(x + width, y);
      ctx.lineTo(x + (width * 2) / 3, y + height);
      ctx.lineTo(x + (width * 2) / 3, y);
    },
  ],
  [
    "kl",
    (ctx, height, width, x, y) => {
      ctx.moveTo(x + width / 3, y);
      ctx.lineTo(x + width / 3, y + height);
      ctx.lineTo(x, y + height);
      ctx.lineTo(x, y);
      ctx.lineTo(x + width, y);
      ctx.lineTo(x + width, y + height);
    },
  ],
  [
    "kr",
    (ctx, height, width, x, y) => {
      ctx.lineTo(x + width, y);
      ctx.lineTo(x + width, y + height);
      ctx.moveTo(x, y);
      ctx.lineTo(x + width / 4, y + height);
      ctx.lineTo(x + width / 2, y);
    },
  ],
  [
    "gl",
    (ctx, height, width, x, y) => {
      ctx.moveTo(x + width / 3, y);
      ctx.lineTo(x + width / 3, y + height);
      ctx.lineTo(x, y + height);
      ctx.lineTo(x, y);
      ctx.lineTo(x + width, y);
      ctx.lineTo(x + width, y + height);
      ctx.moveTo(x + (width * 2) / 3, y);
      ctx.lineTo(x + (width * 2) / 3, y + height);
    },
  ],
  [
    "gr",
    (ctx, height, width, x, y) => {
      ctx.lineTo(x + width, y);
      ctx.lineTo(x + width, y + height);
      ctx.moveTo(x, y);
      ctx.lineTo(x + width / 3, y + height);
      ctx.lineTo(x + (width * 2) / 3, y);
      ctx.moveTo(x + (width * 2) / 3, y);
      ctx.lineTo(x + (width * 2) / 3, y + height);
    },
  ],
  ["Noun", noun],
  [
    "Associative noun",
    (ctx, height, width, x, y) => {
      ctx.moveTo(x + width, y + height);
      ctx.ellipse(
        x + width,
        y + height / 2,
        width,
        height / 2,
        0,
        Math.PI / 2,
        Math.PI * 1.5
      );
      ctx.moveTo(x, y + height / 2);
      ctx.lineTo(x + width, y + height / 2);
    },
  ],
  [
    "0-verb",
    (ctx, height, width, x, y) => {
      ctx.lineTo(x + width / 2, y + height / 2);
      ctx.lineTo(x + width, y);
      ctx.moveTo(x, y + height / 2);
      ctx.lineTo(x + width / 2, y + height);
      ctx.lineTo(x + width, y + height / 2);
    },
  ],
  [
    "1-verb",
    (ctx, height, width, x, y) => {
      ctx.moveTo(x, y + height / 2);
      ctx.lineTo(x + width, y + height / 2);
      ctx.moveTo(x + width / 2, y);
      ctx.lineTo(x + width / 2, y + height);
    },
  ],
  [
    "1-2-verb",
    (ctx, height, width, x, y) => {
      ctx.lineTo(x + width, y);
      ctx.lineTo(x, y + height);
      ctx.lineTo(x + width, y + height);
    },
  ],
  [
    "1-3-verb",
    (ctx, height, width, x, y) => {
      ctx.lineTo(x + width, y);
      ctx.moveTo(x + width / 2, y);
      ctx.lineTo(x + width / 2, y + height);
      ctx.moveTo(x, y + height);
      ctx.lineTo(x + width, y + height);
    },
  ],
  [
    "2-verb",
    (ctx, height, width, x, y) => {
      ctx.lineTo(x + width / 2, y + height / 2);
      ctx.lineTo(x + width, y);
      ctx.moveTo(x, y + height / 2);
      ctx.lineTo(x + width, y + height / 2);
      ctx.moveTo(x + width / 2, y + height / 2);
      ctx.lineTo(x + width / 2, y + height);
    },
  ],
  [
    "2-3-verb",
    (ctx, height, width, x, y) => {
      ctx.lineTo(x + width / 2, y + height / 2);
      ctx.lineTo(x + width, y);
      ctx.moveTo(x, y + height / 2);
      ctx.lineTo(x + width, y + height / 2);
      ctx.moveTo(x + width / 2, y + height / 2);
      ctx.lineTo(x + width / 2, y + height);
      ctx.moveTo(x, y + height);
      ctx.lineTo(x + width, y + height);
    },
  ],
  [
    "3-verb",
    (ctx, height, width, x, y) => {
      ctx.lineTo(x + width / 2, y + height / 2);
      ctx.lineTo(x + width, y);
      ctx.moveTo(x + width / 2, y + height / 2);
      ctx.lineTo(x + width / 2, y + height);
      ctx.moveTo(x, y + height);
      ctx.lineTo(x + width, y + height);
    },
  ],
  [
    "1-2-3-verb",
    (ctx, height, width, x, y) => {
      ctx.lineTo(x + width, y);
      ctx.lineTo(x, y + height);
      ctx.lineTo(x + width, y + height);
      ctx.moveTo(x, y + height / 2);
      ctx.lineTo(x + width, y + height / 2);
    },
  ],
  [
    "Pronoun",
    (ctx, height, width, x, y) => {
      ctx.moveTo(x, y + height);
      ctx.lineTo(x + width, y + height);
      ctx.lineTo(x + width, y);
      ctx.moveTo(x + width / 2, y);
      ctx.lineTo(x + width / 2, y + height);
    },
  ],
  [
    "Modifier",
    (ctx, height, width, x, y) => {
      ctx.lineTo(x + width, y);
      ctx.lineTo(x + width, y + height);
    },
  ],
  [
    "Digit",
    (ctx, height, width, x, y) => {
      ctx.lineTo(x, y + height);
    },
  ],
  [
    "Name",
    (ctx, height, width, x, y) => {
      ctx.lineTo(x + width, y);
      ctx.lineTo(x + width, y + height);
      ctx.lineTo(x, y + height);
    },
  ],
]);

const width = 23;
const singleWidth = 15;
const halfWidth = 8;
const vowels = new Set(["i", "e", "a", "u", "o", "ɒ"]);

const drawTimeran = (
  syllables: string[],
  height: number,
  space: number,
  wordType: string,
  canvas: HTMLCanvasElement
) => {
  const halfHeight = height / 2;
  const fullHeight = height + space;
  const ctx = canvas.getContext("2d")!;
  const path = new Path2D();
  ctx.clearRect(0, 0, ctx.canvas.width, ctx.canvas.height);
  ctx.beginPath();
  let x = 5,
    y = 5;
  syllables.forEach((syllable) => {
    path.moveTo(x, y);
    switch (syllable.length) {
      case 1:
        drawFunctions
          .get(syllable)
          ?.call(null, path, fullHeight, singleWidth, x, y);
        x -= width - singleWidth;
        break;
      case 2: // VC
        if (vowels.has(syllable.charAt(0))) {
          drawFunctions
            .get(syllable.charAt(0))
            ?.call(null, path, fullHeight, halfWidth, x, y);
          path.moveTo(x + halfWidth + space, y);
          drawFunctions
            .get(syllable.charAt(1))
            ?.call(null, path, fullHeight, halfWidth, x + halfWidth + space, y);
        } else {
          // CV
          drawFunctions
            .get(syllable.charAt(0))
            ?.call(null, path, halfHeight, singleWidth, x, y);
          path.moveTo(x, y + halfHeight + space);
          drawFunctions
            .get(syllable.charAt(1))
            ?.call(
              null,
              path,
              halfHeight,
              singleWidth,
              x,
              y + halfHeight + space
            );
          x -= width - singleWidth;
        }
        break;
      case 3: // CCV
        if (vowels.has(syllable.charAt(2))) {
          drawFunctions
            .get(syllable.substr(0, 2))
            ?.call(null, path, halfHeight, width, x, y);
          path.moveTo(x, y + halfHeight + space);
          drawFunctions
            .get(syllable.charAt(2))
            ?.call(null, path, halfHeight, width, x, y + halfHeight + space);
        } else {
          // CVC
          drawFunctions
            .get(syllable.charAt(0))
            ?.call(null, path, halfHeight, width, x, y);
          path.moveTo(x, y + halfHeight + space);
          drawFunctions
            .get(syllable.charAt(1))
            ?.call(
              null,
              path,
              halfHeight,
              halfWidth,
              x,
              y + halfHeight + space
            );
          path.moveTo(x + halfWidth + space, y + halfHeight + space);
          drawFunctions
            .get(syllable.charAt(2))
            ?.call(
              null,
              path,
              halfHeight,
              halfWidth,
              x + halfWidth + space,
              y + halfHeight + space
            );
        }
        break;
      case 4: // CCVC
        drawFunctions
          .get(syllable.substring(0, 2))
          ?.call(null, path, halfHeight, width, x, y);
        path.moveTo(x, y + halfHeight + space);
        drawFunctions
          .get(syllable.charAt(2))
          ?.call(null, path, halfHeight, halfWidth, x, y + halfHeight + space);
        path.moveTo(x + halfWidth + space, y + halfHeight + space);
        drawFunctions
          .get(syllable.charAt(3))
          ?.call(
            null,
            path,
            halfHeight,
            halfWidth,
            x + halfWidth + space,
            y + halfHeight + space
          );
        break;
    }
    x += width + space;
  });
  path.moveTo(x, y);
  drawFunctions.get(wordType)?.call(null, path, fullHeight, width / 2, x, y);
  x += width + space;
  ctx.canvas.width = x;
  ctx.lineCap = "round";
  ctx.lineWidth = 4.7;
  ctx.lineJoin = "round";
  ctx.strokeStyle = "#e0e6f8";
  ctx.stroke(path);
};
