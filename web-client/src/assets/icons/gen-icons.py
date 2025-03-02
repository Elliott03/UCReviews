import json
import os
from PIL import Image, ImageOps, ImageStat

def load_manifest(manifest_path):
    with open(manifest_path, "r") as f:
        return json.load(f)

def get_most_prevalent_color(image):
    image = image.convert("RGB")
    stat = ImageStat.Stat(image)
    return tuple(int(x) for x in stat.median)

def generate_icons(manifest, source_image, output_dir):
    if not os.path.exists(output_dir):
        os.makedirs(output_dir)

    with Image.open(source_image) as img:
        predominant_color = get_most_prevalent_color(img)

        for icon in manifest.get("icons", []):
            size = int(icon["sizes"].split("x")[0])  # Extract size from "72x72"
            output_path = os.path.join(output_dir, os.path.basename(icon["src"]))

            # Calculate padding (1/6th of the size)
            border_size = size // 6
            new_size = size - 2 * border_size

            # Resize and add padding
            img_resized = img.resize((new_size, new_size), Image.ANTIALIAS)
            img_with_border = ImageOps.expand(img_resized, border=border_size, fill=predominant_color)

            img_with_border.save(output_path, "PNG")
            print(f"Generated: {output_path}")

def main():
    manifest_path = "manifest.webmanifest"
    source_image = "ucreviews-logo.png"
    output_dir = "icons"

    if not os.path.exists(source_image):
        print(f"Error: Source image '{source_image}' not found.")
        return

    manifest = load_manifest(manifest_path)
    generate_icons(manifest, source_image, output_dir)
    print("Icon generation completed.")

if __name__ == "__main__":
    main()
