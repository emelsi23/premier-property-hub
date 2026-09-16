(function () {
  function initHero(root) {
    const slides = Array.from(root.querySelectorAll(".iw-hero-slide"));
    const dots = Array.from(root.querySelectorAll("[data-hero-dot]"));
    if (slides.length < 2) return;

    let index = 0;
    let timer;

    function go(n) {
      index = (n + slides.length) % slides.length;
      slides.forEach((s, i) => s.classList.toggle("is-active", i === index));
      dots.forEach((d, i) => d.classList.toggle("is-active", i === index));
    }

    function next() {
      go(index + 1);
    }

    function start() {
      stop();
      timer = setInterval(next, 5500);
    }

    function stop() {
      if (timer) clearInterval(timer);
    }

    root.querySelector("[data-hero-prev]")?.addEventListener("click", () => {
      go(index - 1);
      start();
    });
    root.querySelector("[data-hero-next]")?.addEventListener("click", () => {
      go(index + 1);
      start();
    });
    dots.forEach((dot, i) =>
      dot.addEventListener("click", () => {
        go(i);
        start();
      })
    );

    root.addEventListener("mouseenter", stop);
    root.addEventListener("mouseleave", start);
    go(0);
    start();
  }

  function initTrack(root) {
    const track = root.querySelector("[data-carousel-track]");
    if (!track) return;

    const prev = root.querySelector("[data-carousel-prev]");
    const next = root.querySelector("[data-carousel-next]");

    function step() {
      const card = track.querySelector(".iw-card, .iw-cat-slide");
      return card ? card.getBoundingClientRect().width + 18 : 280;
    }

    prev?.addEventListener("click", () => {
      track.scrollBy({ left: -step(), behavior: "smooth" });
    });
    next?.addEventListener("click", () => {
      track.scrollBy({ left: step(), behavior: "smooth" });
    });
  }

  function initGallery() {
    const main = document.getElementById("iwMainPhoto");
    const thumbs = document.getElementById("iwThumbs");
    if (!main || !thumbs) return;

    const buttons = Array.from(thumbs.querySelectorAll("button"));
    let index = 0;

    function show(i) {
      index = (i + buttons.length) % buttons.length;
      const src = buttons[index].getAttribute("data-src");
      if (!src) return;
      main.classList.remove("iw-fade");
      void main.offsetWidth;
      main.src = src;
      main.classList.add("iw-fade");
      buttons.forEach((b, n) => b.classList.toggle("is-active", n === index));
    }

    buttons.forEach((btn, i) =>
      btn.addEventListener("click", () => show(i))
    );

    document.querySelector("[data-gallery-prev]")?.addEventListener("click", () => show(index - 1));
    document.querySelector("[data-gallery-next]")?.addEventListener("click", () => show(index + 1));
  }

  document.querySelectorAll("[data-hero-carousel]").forEach(initHero);
  document.querySelectorAll("[data-carousel]").forEach(initTrack);
  initGallery();
})();
