from flask import Flask, render_template, request
import os

app = Flask(__name__)

def display_hex(file_path, chunk_size=32):
    try:
        with open(file_path, 'rb') as file:
            offset = 0
            hex_lines = [" "]
            while True:
                chunk = file.read(chunk_size)
                if not chunk:
                    break

                hex_data = ' '.join([f'{byte:02X}' for byte in chunk])
                ascii_data = ''.join([chr(byte) if 32 <= byte <= 126 else '.' for byte in chunk])

                hex_lines.append(f'{offset:08X}: {hex_data.ljust(chunk_size * 3)}  {ascii_data}')
                offset += len(chunk)

            return '\n'.join(hex_lines)

    except FileNotFoundError:
        return f"File not found: {file_path}"
    except Exception as e:
        return f"An error occurred: {str(e)}"


@app.route('/', methods=['GET', 'POST'])
def index():
    if request.method == 'POST':
        uploaded_file = request.files['file']
        if uploaded_file:
            file_path = os.path.join('uploads', uploaded_file.filename)
            uploaded_file.save(file_path)
            hex_lines = display_hex(file_path)
            return render_template('index.html', hex_lines=hex_lines)

    return render_template('index.html', hex_lines=None)

if __name__ == '__main__':
    app.run(debug=True)
