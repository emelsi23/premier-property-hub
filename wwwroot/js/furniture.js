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

    let buttons = [];
    let index = 0;

    function bind() {
      buttons = Array.from(thumbs.querySelectorAll("button"));
      buttons.forEach((btn, i) => {
        btn.onclick = () => show(i);
      });
      if (buttons.length) show(0);
    }

    function show(i) {
      if (!buttons.length) return;
      index = (i + buttons.length) % buttons.length;
      const src = buttons[index].getAttribute("data-src");
      if (!src) return;
      main.classList.remove("iw-fade");
      void main.offsetWidth;
      main.src = src;
      main.classList.add("iw-fade");
      buttons.forEach((b, n) => b.classList.toggle("is-active", n === index));
    }

    document.querySelector("[data-gallery-prev]")?.addEventListener("click", () => show(index - 1));
    document.querySelector("[data-gallery-next]")?.addEventListener("click", () => show(index + 1));

    window.__iwGallery = { bind, show, getIndex: () => index };
    bind();
  }

  function initColorCustomize() {
    const root = document.getElementById("iwProductDetail");
    if (!root) return;

    const swatches = Array.from(root.querySelectorAll(".iw-swatch"));
    if (!swatches.length) return;

    const photoDataEl = document.getElementById("iwPhotoData");
    const allPhotos = photoDataEl ? JSON.parse(photoDataEl.textContent || "[]") : [];
    const thumbs = document.getElementById("iwThumbs");
    const main = document.getElementById("iwMainPhoto");
    const tint = document.getElementById("iwColorTint");
    const nameEl = document.getElementById("iwColorName");
    const waBtn = document.getElementById("iwWaBtn");
    const strength = document.getElementById("iwTintStrength");
    const allowPreview = root.getAttribute("data-allow-preview") === "true";
    const title = root.getAttribute("data-title") || "";
    const sku = root.getAttribute("data-sku") || "";
    const url = root.getAttribute("data-url") || "";
    const waNumber = root.getAttribute("data-wa-number") || "19453846408";

    const strengthWrap = strength?.closest(".iw-tint-controls");
    const noteEl = root.querySelector(".iw-customize-note");

    let selected = {
      id: swatches.find((s) => s.classList.contains("is-active"))?.getAttribute("data-color-id"),
      name: swatches.find((s) => s.classList.contains("is-active"))?.getAttribute("data-color-name") || "",
      hex: swatches.find((s) => s.classList.contains("is-active"))?.getAttribute("data-color-hex") || "#C4A574"
    };
    let usingDedicated = false;

    function buildWa() {
      if (!waBtn) return;
      const colorPart = selected.name ? ` · Color: ${selected.name}` : "";
      const msg = `Hola, me interesa: ${title} (SKU ${sku})${colorPart} — ${url}`;
      waBtn.href = `https://wa.me/${waNumber}?text=${encodeURIComponent(msg)}`;
    }

    function renderThumbs(list) {
      if (!thumbs) return;
      thumbs.innerHTML = "";
      list.forEach((ph, i) => {
        const btn = document.createElement("button");
        btn.type = "button";
        btn.setAttribute("data-src", ph.url);
        btn.setAttribute("data-color-id", ph.colorId == null ? "" : String(ph.colorId));
        if (i === 0) btn.classList.add("is-active");
        btn.innerHTML = `<img src="${ph.url}" alt="" />`;
        thumbs.appendChild(btn);
      });
      window.__iwGallery?.bind();
      if (list[0] && main) {
        main.src = list[0].url;
        main.classList.remove("iw-fade");
        void main.offsetWidth;
        main.classList.add("iw-fade");
      }
    }

    function applyTint() {
      if (!tint || !allowPreview) return;
      if (usingDedicated) {
        tint.hidden = true;
        if (strengthWrap) strengthWrap.hidden = true;
        if (noteEl) noteEl.hidden = true;
        return;
      }
      if (strengthWrap) strengthWrap.hidden = false;
      if (noteEl) noteEl.hidden = false;
      const pct = strength ? Number(strength.value) : 32;
      tint.style.background = selected.hex;
      tint.style.opacity = String(pct / 100);
      tint.hidden = false;
    }

    function selectSwatch(btn) {
      selected = {
        id: btn.getAttribute("data-color-id"),
        name: btn.getAttribute("data-color-name") || "",
        hex: btn.getAttribute("data-color-hex") || "#C4A574"
      };
      swatches.forEach((s) => {
        const on = s === btn;
        s.classList.toggle("is-active", on);
        s.setAttribute("aria-selected", on ? "true" : "false");
      });
      if (nameEl) nameEl.textContent = selected.name;

      const colorId = selected.id ? Number(selected.id) : null;
      const dedicated = allPhotos.filter((p) => Number(p.colorId) === colorId);
      const shared = allPhotos.filter((p) => p.colorId == null);
      usingDedicated = dedicated.length > 0;
      const list = usingDedicated ? dedicated : shared.length ? shared : allPhotos;
      renderThumbs(list);
      applyTint();
      buildWa();
    }

    swatches.forEach((btn) => btn.addEventListener("click", () => selectSwatch(btn)));
    strength?.addEventListener("input", applyTint);

    const active = swatches.find((s) => s.classList.contains("is-active")) || swatches[0];
    if (active) selectSwatch(active);
  }

  document.querySelectorAll("[data-hero-carousel]").forEach(initHero);
  document.querySelectorAll("[data-carousel]").forEach(initTrack);
  initGallery();
  initColorCustomize();
})();
